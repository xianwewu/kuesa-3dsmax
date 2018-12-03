/*
    KdabProperties.h

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

#include <vector>
#include <numeric>
#include <sstream>

#include <istdplug.h>

class KdabProperties
{
public:
    static void setStringArrayProperty(INode *node, const std::wstring &key, const std::vector<std::wstring> &value, const wchar_t separator = L';');
    static std::vector<std::wstring> getStringArrayProperty(INode *node, const std::wstring &key, const wchar_t &separator = L';');
    static bool removeProperty(INode *node, const std::wstring &key);

private:
    static void replaceSubString(std::wstring &s, const std::wstring &find, const std::wstring &replace);
    static void trimSpaceLeft(std::wstring &s);
    static void trimSpaceRight(std::wstring &s);
    static void trimSpace(std::wstring &s);
};
