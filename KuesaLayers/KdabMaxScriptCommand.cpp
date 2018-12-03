/*
    KdabMaxScriptCommand.cpp

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

#include "KdabMaxScriptCommand.h"

#include "KdabLog.h"

KdabMaxScriptCommand::KdabMaxScriptCommand(Interface *maxInterface, Value **args, int numArgs)
  : m_maxInterface(maxInterface)
{
    m_args = new KdabMaxScriptArguments(args, numArgs);
}

KdabMaxScriptCommand::~KdabMaxScriptCommand()
{
}

Interface *KdabMaxScriptCommand::getMaxInterface() const
{
    return m_maxInterface;
}

KdabMaxScriptArguments *KdabMaxScriptCommand::getArgs() const
{
    return m_args;
}

void KdabMaxScriptCommand::gatherInputNodes(bool defaultInSelected)
{
    KLOG.dbg(L"gatherInputNodes()...");
    m_inputNodes.clear();

    Value *inAllNodes = m_args->getValueByKey(L"inAllNodes");
    if (inAllNodes) {
        traverseSceneNodes([this](INode *node, int depth) {
            if (depth > 0)
                m_inputNodes.insert(node);
            return true;
        });
    } else {
        INode *node = m_args->getNodeByKey(L"inNode");
        if (node)
            m_inputNodes.insert(node);

        std::vector<INode*> nodes;
        bool inNodes = m_args->getNodeArrayByKey(L"inNodes", nodes);
        if (inNodes) {
            for (auto node : nodes)
                m_inputNodes.insert(node);
        }

        inNodes |= (node != nullptr);

        const bool inSelected = m_args->getValueByKey(L"inSelectedNodes") != nullptr;
        if ((inNodes && inSelected) || (!inNodes && (inSelected || defaultInSelected))) {
            forAllSelectedNodes([this](INode *node) {
                m_inputNodes.insert(node);
                return true;
            });
        }
    }

    KLOG.getStream() << "gathered " << m_inputNodes.size() << " nodes:";
    KLOG.flushDbg();
    for (const auto &i: m_inputNodes) {
        KLOG.getStream() << L"  " << i->GetName();
        KLOG.flushDbg();
    }
}

std::set<INode *> KdabMaxScriptCommand::getInputNodes() const
{
    return m_inputNodes;
}

void KdabMaxScriptCommand::forAllInputNodes(std::function<bool(INode *)> f)
{
    for (auto &node: m_inputNodes) {
        if (!f(node))
            return;
    }
}

void KdabMaxScriptCommand::traverseSceneNodes(std::function<bool(INode *, int)> f, INode *rootNode, int depth)
{
    if (rootNode == nullptr)
        rootNode = m_maxInterface->GetRootNode();
    if (f(rootNode, depth)) {
        for (int iChild = 0; iChild < rootNode->NumberOfChildren(); ++iChild)
            traverseSceneNodes(f, rootNode->GetChildNode(iChild), depth + 1);
    }
}

void KdabMaxScriptCommand::forAllSelectedNodes(std::function<bool(INode *)> f)
{
    for (int i = 0; i < m_maxInterface->GetSelNodeCount(); ++i) {
        if (!f(m_maxInterface->GetSelNode(i)))
            return;
    }
}
