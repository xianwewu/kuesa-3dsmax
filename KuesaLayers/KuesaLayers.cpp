/*
    KuesaLayers.cpp

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

#include "KuesaLayers.h"

#include "KuesaLayersCommand.h" // MaxScript command

#define KuesaLayers_CLASS_ID Class_ID(0x33c27542, 0xd3d8b90f)

class KuesaLayers : public UtilityObj
{
public:
    KuesaLayers();
    ~KuesaLayers();

    virtual void DeleteThis() {}

    virtual void BeginEditParams(Interface *ip, IUtil *iu);
    virtual void EndEditParams(Interface *ip, IUtil *iu);

    virtual void Init(HWND hWnd);
    virtual void Destroy(HWND hWnd);

    // Singleton access
    static KuesaLayers *GetInstance()
    {
        static KuesaLayers theKuesaLayers;
        return &theKuesaLayers;
    }

private:
    static INT_PTR CALLBACK DlgProc(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam);

    HWND hPanel;
    IUtil *iu;
};

class KuesaLayersClassDesc : public ClassDesc2
{
public:
    virtual int IsPublic() { return TRUE; }
    virtual void *Create(BOOL /*loading = FALSE*/) { return KuesaLayers::GetInstance(); }
    virtual const TCHAR *ClassName() { return GetString(IDS_CLASS_NAME); }
    virtual SClass_ID SuperClassID() { return UTILITY_CLASS_ID; }
    virtual Class_ID ClassID() { return KuesaLayers_CLASS_ID; }
    virtual const TCHAR *Category() { return GetString(IDS_CATEGORY); }

    virtual const TCHAR *InternalName() { return _T("KuesaLayers"); } // returns fixed parsable name (scripter-visible name)
    virtual HINSTANCE HInstance() { return hInstance; } // returns owning module handle
};

ClassDesc2 *GetKuesaLayersDesc()
{
    static KuesaLayersClassDesc KuesaLayersDesc;
    return &KuesaLayersDesc;
}

//--- KuesaLayers -------------------------------------------------------
KuesaLayers::KuesaLayers()
    : hPanel(nullptr)
    , iu(nullptr)
{
}

KuesaLayers::~KuesaLayers()
{
}

void KuesaLayers::BeginEditParams(Interface *ip, IUtil *iu)
{
    this->iu = iu;
    hPanel = ip->AddRollupPage(
            hInstance,
            MAKEINTRESOURCE(IDD_PANEL),
            DlgProc,
            GetString(IDS_PARAMS),
            0);
}

void KuesaLayers::EndEditParams(Interface *ip, IUtil *)
{
    this->iu = nullptr;
    ip->DeleteRollupPage(hPanel);
    hPanel = nullptr;
}

void KuesaLayers::Init(HWND /*handle*/)
{
}

void KuesaLayers::Destroy(HWND /*handle*/)
{
}

INT_PTR CALLBACK KuesaLayers::DlgProc(HWND hWnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
    switch (msg) {
    case WM_INITDIALOG:
        KuesaLayers::GetInstance()->Init(hWnd);
        break;

    case WM_DESTROY:
        KuesaLayers::GetInstance()->Destroy(hWnd);
        break;

    case WM_COMMAND:
#pragma message(TODO("React to the user interface commands.  A utility plug-in is controlled by the user from here."))
        break;

    case WM_LBUTTONDOWN:
    case WM_LBUTTONUP:
    case WM_MOUSEMOVE:
        GetCOREInterface()->RollupMouseMessage(hWnd, msg, wParam, lParam);
        break;

    default:
        return 0;
    }
    return 1;
}
