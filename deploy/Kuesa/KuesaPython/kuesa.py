import sys
import os

import MaxPlus
import pymxs

def init_kuesa():
    kuesa_python_path = os.path.split(sys.argv[0])[0]
    kuesa_python_path = os.path.abspath(kuesa_python_path)

    max_root_path = MaxPlus.PathManager.GetMaxSysRootDir()
    max_root_path = os.path.abspath(max_root_path)

    if kuesa_python_path.startswith(max_root_path):
        print("Kuesa plugins must not be copied into a subfolder of 3DS Max!")
    else:
        sys.path.append(kuesa_python_path)
        import KuesaPython
        KuesaPython.KuesaMenu.init()

init_kuesa()
