/*
    KuesaLayersCommand.cpp

    This file is part of Kuesa.

    Copyright (C) 2018 Klarälvdalens Datakonsult AB, a KDAB Group company, info@kdab.com
    Author: Timo Buske <timo.buske@kdab.com>

    Licensees holding valid proprietary KDAB Kuesa licenses may use this file in
    accordance with the Kuesa Enterprise License Agreement provided with the Software in the
    LICENSE.KUESA.ENTERPRISE file.

    Contact info@kdab.com if any conditions of this licensing are not clear to you.

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU Affero General Public License as
    published by the Free Software Foundation, either version 3 of the
    License, or (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Affero General Public License for more details.

    You should have received a copy of the GNU Affero General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

#include "KuesaLayersCommand.h"

#include <sstream>
#include <vector>
#include <locale>
#include <codecvt>
#include <string>
#include <algorithm>
#include <set>

#include "KdabProperties.h"
#include "KdabLog.h"

KuesaLayersCommand::KuesaLayersCommand(Interface *maxInterface, Value **args, int numArgs)
    : KdabMaxScriptCommand(maxInterface, args, numArgs)
{
}

Value *KuesaLayersCommand::doIt()
{
    KLOG.dbg(L"KuesaLayersCommand::doIt()");

    gatherInputNodes(false);

    std::wstring layerName;
    std::vector<std::wstring> layerNames;
    bool foundKey = false;
    layerName = getArgs()->getStringByKey(L"addLayer", foundKey);
    if (foundKey) {
        forAllInputNodes([this, &layerName](INode *node) {
            addLayerToNode(node, layerName);
            return true;
        });
    }
    if (getArgs()->getStringArrayByKey(L"addLayers", layerNames)) {
        forAllInputNodes([this, &layerNames](INode *node) {
            for (const auto &layerName : layerNames)
                addLayerToNode(node, layerName);
            return true;
        });
    }
    layerName = getArgs()->getStringByKey(L"delLayer", foundKey);
    if (foundKey) {
        forAllInputNodes([this, &layerName](INode *node) {
            delLayerFromNode(node, layerName);
            return true;
        });
    }
    if (getArgs()->getStringArrayByKey(L"delLayers", layerNames)) {
        forAllInputNodes([this, &layerNames](INode *node) {
            for (const auto &layerName : layerNames)
                delLayerFromNode(node, layerName);
            return true;
        });
    }

    if (getArgs()->getValueByKey(L"getLayers")) {
        std::set<std::wstring> gatheredLayerNames;
        forAllInputNodes([this, &gatheredLayerNames](INode *node) {
            gatherLayersFromNodeAppend(node, gatheredLayerNames);
            return true;
        });

        Value **v;
        value_local_array(v, gatheredLayerNames.size() + 1);
        v[gatheredLayerNames.size() - 1] = new Array(static_cast<int>(gatheredLayerNames.size()));
        Array *a = static_cast<Array *>(v[gatheredLayerNames.size() - 1]);
        int count = 0;
        for (const auto &layer : gatheredLayerNames) {
            v[count] = new String(layer.c_str());
            a->append(v[count]);
            ++count;
        }
        return_value(a);
    }

    return &ok;
}

Value *KuesaLayersCommand::addLayerToNode(INode *node, const std::wstring &layerName)
{
    KLOG.dbg(L"addLayerToNode()...");
    KLOG.getStream() << node->GetName() << L" <- " << layerName;
    KLOG.flushDbg();

    auto layers = KdabProperties::getStringArrayProperty(node, KuesaLayersCommand::propertyKey);
    if (std::find(layers.begin(), layers.end(), layerName) == layers.end()) {
        layers.push_back(layerName);
        KdabProperties::setStringArrayProperty(node, KuesaLayersCommand::propertyKey, layers);
    }

    return &ok;
}

Value *KuesaLayersCommand::delLayerFromNode(INode *node, const std::wstring &layerName)
{
    KLOG.dbg(L"removeLayerFromNode()...");
    KLOG.getStream() << node->GetName() << L": " << layerName << L" ->";
    KLOG.flushDbg();

    std::vector<std::wstring> newLayers;
    auto oldLayers = KdabProperties::getStringArrayProperty(node, KuesaLayersCommand::propertyKey);
    for (const auto &i : oldLayers) {
        if (i != layerName)
            newLayers.push_back(i);
    }

    if (newLayers.empty())
        KdabProperties::removeProperty(node, KuesaLayersCommand::propertyKey);
    else
        KdabProperties::setStringArrayProperty(node, KuesaLayersCommand::propertyKey, newLayers);

    return &ok;
}

Value *KuesaLayersCommand::gatherLayersFromNodeAppend(INode *node, std::set<std::wstring> &layers)
{
    KLOG.dbg(L"gatherLayersFromNode()...");
    KLOG.dbg(node->GetName());

    auto layersFromNode = KdabProperties::getStringArrayProperty(node, KuesaLayersCommand::propertyKey);
    for (const auto &layer : layersFromNode)
        layers.insert(layer);

    return &ok;
}

std::wstring KuesaLayersCommand::propertyKey = L"kuesa_layers";

VISIBLE_PRIMITIVE(KuesaLayersCommand, "KuesaLayers")
