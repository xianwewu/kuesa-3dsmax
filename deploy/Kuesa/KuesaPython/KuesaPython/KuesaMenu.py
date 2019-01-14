from PySide2 import QtCore
from PySide2 import QtWidgets
import MaxPlus
import pymxs

import KuesaLayersUi

ACTIONS = None # keep new actions persistent
EXPORTER_ACTION = None

class ActionTools (object):

    @staticmethod
    def find_action_by_menu_sub_text(menu_sub_text, category_sub_text=None):
        for i in range(MaxPlus.ActionManager_GetNumActionTables()):
            actionTable = MaxPlus.ActionManager.GetActionTable(i)
            for k in range(actionTable.GetNumActions()):
                action = actionTable.GetAction(k)
                if category_sub_text is not None:
                    if category_sub_text not in action.GetCategoryText():
                        break
                if menu_sub_text in action.GetMenuText():
                    return action
        print("ERROR: Action *{}*.*{}* not found.".format(category_sub_text, menu_sub_text))
        return None

class KuesaMenu (object):

    @staticmethod
    def init():
        print("Initializing KDAB Kuesa menu V 0.1 [2019-01-14]...")
        KuesaMenu.createMenu("Kuesa", [
            {"name": "Kuesa Layer Manager", "function": KuesaMenu.kuesaLayerManagerCallback},
            {"separator": True},
            {"name": "Kuesa Export",  "function": KuesaMenu.kuesaExportCallback}
        ])

    @staticmethod
    def createMenu(menu_name, menu_definition):
        global ACTIONS
        if ACTIONS is None:
            ACTIONS = []

        MaxPlus.MenuManager.UnregisterMenu(menu_name)
        menuBuilder = MaxPlus.MenuBuilder(menu_name)

        for item in menu_definition:
            if "separator" in item:
                menuBuilder.AddSeparator()
            else:
                action = MaxPlus.ActionFactory.Create(item["name"], item["name"], item["function"])
                ACTIONS.append(action)
                menuBuilder.AddItem(action)

        menu = menuBuilder.Create(MaxPlus.MenuManager.GetMainMenu())

        if MaxPlus.MenuManager.FindMenu(menu_name) is None:
            print("ERROR: Couldn't initialize Kuesa menu.")
        else:
            print("Kuesa menu initialized.")

    @staticmethod
    def kuesaLayerManagerCallback():
        KuesaLayersUi.KuesaLayersUi()

    @staticmethod
    def kuesaExportCallback():
        global EXPORTER_ACTION
        if EXPORTER_ACTION is None:
            EXPORTER_ACTION = ActionTools.find_action_by_menu_sub_text("File Exporter", "Kuesa")
        if EXPORTER_ACTION is None:
            print("ERROR: Unable to find Kuesa Exporter. Please make sure 'KuesaMax2Babylon.dll' lives in <3dsMax>/bin/assemblies/!")
        KuesaMenu.executeAction(EXPORTER_ACTION)

    @staticmethod
    def executeAction(action):
        if action is None:
            print("ERROR: No action to exectute.")
        else:
            action.Execute()
