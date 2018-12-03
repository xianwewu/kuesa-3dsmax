/*
    KuesaLayersCommand.h

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

#pragma once

#include "KdabMaxScriptCommand.h"

#include <maxapi.h>
#include <maxscript/maxscript.h>

// This is what happens under the hood when editing Kuesa Layers
// for 3DS Max objects. The command is available via MaxScript and Python.
// UI is not part of this command.
class KuesaLayersCommand : public KdabMaxScriptCommand
{
public:
    KuesaLayersCommand(Interface *maxInterface, Value **args, int numArgs);

    virtual Value *doIt() override;

    Value *addLayerToNode(INode *node, const std::wstring &layerName);
    Value *delLayerFromNode(INode *node, const std::wstring &layerName);
    Value *gatherLayersFromNodeAppend(INode *node, std::set<std::wstring> &layers);

private:
    static std::wstring propertyKey;

    std::vector<std::wstring> m_layerNames;
};
