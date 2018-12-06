/*
    KdabMaxScriptArguments.cpp

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

#include "KdabMaxScriptArguments.h"

#include <maxapi.h>
#include <maxscript/maxscript.h>

#include "KdabMaxScriptCommand.h"
#include "KdabLog.h"

KdabMaxScriptArguments::KdabMaxScriptArguments(Value **args, int numArgs)
{
    int index = 0;
    bool positional = true;
    while (index < numArgs) {
        Value *value = args[index];
        if (positional) { // positional
            if (value->tag == class_tag(Name) && std::wstring(L"#keys").compare(value->to_string()) == 0)
                positional = false;
            else
                m_posArgs.push_back(value);
        } else { // key value
            if (value->tag == class_tag(Name)) {
                std::wstring name = value->to_string();
                ++index;
                KLOG.getStream() << args[index]->tag->name;
                KLOG.flushDbg();
                m_keyArgs[name] = args[index];
            }
        }

        ++index;
    }
}

Value *KdabMaxScriptArguments::getValueByKey(const std::wstring &key) const
{
    auto &dbg = KLOG.getStream();
    dbg << L"getValueByKey() '" << key << L"' ";
    auto value = m_keyArgs.find(key);
    if (value == m_keyArgs.end()) {
        dbg << L"not found, available keys:";
        for (const auto &a : m_keyArgs)
            dbg << " " << a.first;
        KLOG.flushDbg();
        return nullptr;
    }
    dbg << L"found, value type: " << value->second->tag->name;
    KLOG.flushDbg();
    return value->second;
}

INode *KdabMaxScriptArguments::getNodeByKey(const std::wstring &key) const
{
    KLOG.dbg(L"getNodeByKey()...");
    Value *value = getValueByKey(key);
    if (!value) {
        return nullptr;
    }
    if (std::wstring(L"Object").compare(value->tag->name) != 0) {
        KLOG.dbg(L"  not a node");
        return nullptr;
    }
    return value->to_node();
}

std::wstring KdabMaxScriptArguments::getStringByKey(const std::wstring &key, bool &okay) const
{
    KLOG.dbg(L"getStringByKey()...");
    Value *value = getValueByKey(key);
    if (!value || value->tag != class_tag(String)) {
        okay = false;
        return std::wstring();
    }
    okay = true;
    return std::wstring(value->to_string());
}

Value *KdabMaxScriptArguments::getArrayValueByKey(const std::wstring &key) const
{
    KLOG.dbg(L"getArrayValueByKey()...");
    Value *value = getValueByKey(key);
    if (!value)
        return nullptr;
    KLOG.getStream() << L"  value type: " << value->tag->name;
    KLOG.flushDbg();
    if (value->tag == class_tag(Array)) {
        KLOG.dbg(L"  array identified");
        return value;
    }
    KLOG.dbg(L"  not an array");
    return nullptr;
}

bool KdabMaxScriptArguments::getNodeArrayByKey(const std::wstring &key, std::vector<INode *> &values) const
{
    KLOG.dbg(L"getNodeArrayByKey()...");
    values.clear();
    Value *value = getArrayValueByKey(key);
    if (!value)
        return false;
    Array *array = static_cast<Array *>(value);
    for (int i = 0; i < array->size; ++i) {
        Value *value = array->data[i];
        if (std::wstring(L"Object").compare(value->tag->name) == 0) {
            INode *node = value->to_node();
            KLOG.getStream() << L"  found node array item: " << node->GetName();
            KLOG.flushDbg();
            values.push_back(node);
        }
    }
    return true;
}

bool KdabMaxScriptArguments::getStringArrayByKey(const std::wstring &key, std::vector<std::wstring> &values) const
{
    KLOG.dbg(L"getStringArrayByKey()...");
    values.clear();
    Value *value = getArrayValueByKey(key);
    if (!value)
        return false;
    Array *array = static_cast<Array *>(value);
    for (int i = 0; i < array->size; ++i) {
        Value *value = array->data[i];
        if (value->tag == class_tag(String))
            values.push_back(value->to_string());
    }
    KLOG.getStream() << L"  found string array items: " << values.size();
    KLOG.flushDbg();
    return true;
}
