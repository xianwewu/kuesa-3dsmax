/*
    KdabMaxScriptCommand.h

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

#include <sstream>
#include <set>
#include <functional>

#include <maxapi.h>
#include <maxscript/maxscript.h>
#include <maxscript/util/listener.h>
#include <maxscript/macros/define_instantiation_functions.h>

#include "KdabMaxScriptArguments.h"

// Convenience class for new MaxScript commands.
// A NewCustomCommand inherits from KdabMaxScriptCommand.
// Register it in the last line of NewCustomCommand.cpp with :
//   VISIBLE_PRIMITIVE(ClassName, "CommandName")
// Include it in your plugin cpp :
//   #include "NewCustomCommand.h"
// Call it via MaxScript or
// inside C++ via the MaxScript bridge or directly by calling doIt().
class KdabMaxScriptCommand
{
public:
    KdabMaxScriptCommand(Interface *maxInterface, Value **args = nullptr, int numArgs = 0);
    virtual ~KdabMaxScriptCommand();

    virtual Value *doIt() = 0; // command execution

    Interface *getMaxInterface() const; // 3ds max interface to acces application and scene
    KdabMaxScriptArguments *getArgs() const; // maxscript / python command arguments

    void gatherInputNodes(bool defaultInSelected); // 3ds max scene nodes via 'inNode', 'inNodes', 'inSelection', 'inAll' arguments
    std::set<INode *> getInputNodes() const;
    void forAllInputNodes(std::function<bool(INode *)> f);
    void traverseSceneNodes(std::function<bool(INode *, int)> f, INode *rootNode = nullptr, int depth = 0);
    void forAllSelectedNodes(std::function<bool(INode *)> f);

private:
    Interface *m_maxInterface; // 3ds max interface to acces application and scene
    KdabMaxScriptArguments *m_args; // maxscript / python command arguments

    std::set<INode *> m_inputNodes;
};

#define VISIBLE_PRIMITIVE(classname, quotedname) \
def_visible_primitive(classname, quotedname); \
Value* classname##_cf(Value **argList, int numArgs) { \
    classname command(MAXScript_interface, argList, numArgs); \
    return command.doIt(); \
}
