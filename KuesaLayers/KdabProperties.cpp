/*
    KdabProperties.cpp

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

#include "KdabProperties.h"

#include <algorithm>
#include <functional>
#include <cctype>
#include <locale>

void KdabProperties::setStringArrayProperty(INode *node, const std::wstring &key, const std::vector<std::wstring> &value, const wchar_t separator)
{
    std::wstring propertyValue;
    if (!value.empty()) {
        propertyValue = value[0];
        size_t i = 1;
        while (i < value.size()) {
            propertyValue += separator;
            propertyValue += value[i];
            ++i;
        }
    }

    KdabProperties::replaceSubString(propertyValue, L" ", L"_");
    KdabProperties::replaceSubString(propertyValue, L"=", L"_");
    node->SetUserPropString(key.c_str(), propertyValue.c_str());
}

std::vector<std::wstring> KdabProperties::getStringArrayProperty(INode *node, const std::wstring &key, const wchar_t &separator)
{
    std::vector<std::wstring> resultArray;

    MSTR value;
    if (!node->GetUserPropString(key.c_str(), value))
        return resultArray;

    std::wstringstream stream;
    stream << value;
    std::wstring token;
    while (getline(stream, token, separator)) {
        KdabProperties::trimSpace(token);
        if (!token.empty())
            resultArray.push_back(token);
    }

    return resultArray;
}

bool KdabProperties::removeProperty(INode *node, const std::wstring &key)
{
    if (!node->UserPropExists(key.c_str()))
        return false;

    std::wstringstream newPropertiesBlock;

    MSTR buffer;
    node->GetUserPropBuffer(buffer);
    std::wstringstream stream;
    stream << buffer;
    std::wstring line;
    while (getline(stream, line)) {
        size_t index = line.find(L'=');
        if (index == std::wstring::npos) {
            newPropertiesBlock << line << std::endl;
            continue;
        }
        std::wstring currentKey = line.substr(0, index);
        KdabProperties::trimSpace(currentKey);
        if (currentKey != key)
            newPropertiesBlock << line << std::endl;
    }
    node->SetUserPropBuffer(newPropertiesBlock.str().c_str());

    return true;
}

void KdabProperties::replaceSubString(std::wstring &fullString, const std::wstring &find, const std::wstring &replace)
{
    size_t pos = 0;
    while ((pos = fullString.find(find, pos)) != std::wstring::npos) {
        fullString.replace(pos, find.length(), replace);
        pos += replace.length();
    }
}

void KdabProperties::trimSpaceLeft(std::wstring &str)
{
    str.erase(str.begin(), std::find_if(str.begin(), str.end(), std::not1(std::ptr_fun<int, int>(std::isspace))));
}

void KdabProperties::trimSpaceRight(std::wstring &str) {
    str.erase(std::find_if(str.rbegin(), str.rend(), std::not1(std::ptr_fun<int, int>(std::isspace))).base(), str.end());
}

void KdabProperties::trimSpace(std::wstring &str) {
    trimSpaceLeft(str);
    trimSpaceRight(str);
}

