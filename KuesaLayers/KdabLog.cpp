/*
    KdabLog.cpp

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

#include "KdabLog.h"

KdabLog &KdabLog::getInstance()
{
    static KdabLog instance;
    return instance;
}

KdabLog::KdabLog()
  : m_maxInterface(MAXScript_interface),
    m_logLevel(LogLevel::kAll)
{
}

void KdabLog::dbg(const std::wstring &s, bool endl)
{
    if (m_logLevel > LogLevel::kDbg)
        return;
    std::wstringstream stream;
    stream << s;
    if (endl)
        stream << std::endl;
    the_listener->edit_stream->printf(stream.str().c_str());
}

std::wstringstream &KdabLog::getStream()
{
    return m_logStream;
}

void KdabLog::flushDbg(bool endl)
{
    dbg(m_logStream.str(), endl);
    m_logStream.str(std::wstring());
}
