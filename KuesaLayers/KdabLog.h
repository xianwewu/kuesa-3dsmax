/*
    KdabLog.h

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

#include <maxapi.h>
#include <maxscript/maxscript.h>
#include <maxscript/util/listener.h>
#include <maxscript/macros/define_instantiation_functions.h>

class KdabLog
{
public:
    enum class LogLevel
    {
        kAll = 0,
        kDbg,
        kMsg,
        kWrn,
        kErr
    };

    static KdabLog &getInstance();

    KdabLog(const KdabLog &) = delete;
    void operator=(const KdabLog &) = delete;

    void dbg(const std::wstring &s, bool endl = true); // instant debug out
    std::wstringstream &getStream(); // after shifting into stream it needs to be flushed
    void flushDbg(bool endl = true); // flush stream to debug

private:
    KdabLog();

    Interface *m_maxInterface;

    LogLevel m_logLevel;
    std::wstringstream m_logStream;
};

#define KLOG KdabLog::getInstance()
