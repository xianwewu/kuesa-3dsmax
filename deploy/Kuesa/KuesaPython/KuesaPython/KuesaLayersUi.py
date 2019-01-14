from PySide2 import QtCore
from PySide2 import QtWidgets
from PySide2 import QtGui
from PySide2.QtWidgets import QApplication
from PySide2.QtQuick import QQuickView
from PySide2.QtCore import QUrl

import MaxPlus
import pymxs

class LayerItemWidget (QtWidgets.QWidget):

    BUTTON_WIDTH = 16

    name = None
    status = None

    lb_name = None
    ck_status = None
    bt_del = None
    bt_add = None
    bt_sel = None

    def __init__(self, parent=None):
        super(LayerItemWidget, self).__init__(parent)
        layout = QtWidgets.QHBoxLayout(self)
        layout.setContentsMargins(0, 0, 0, 0)

        self.lb_name = QtWidgets.QLabel(self)
        layout.addWidget(self.lb_name)
        layout.addStretch()
        self.ck_status = QtWidgets.QCheckBox(self)
        self.ck_status.setEnabled(False)
        self.ck_status.setTristate(True)
        self.ck_status.setToolTip("Shows KuesaLayers of the selected object(s).\n[ ]: None of the selected objects have that layer.\n[-]: Some of the selected objects have that layer, but not all.\n[v]: All selected objects have that layer.\nYou'll need to refresh, when selection changes.")
        layout.addWidget(self.ck_status)
        self.bt_del = QtWidgets.QPushButton(self)
        self.bt_del.setText("-")
        self.bt_del.setToolTip("Remove selected object(s) from this layer.")
        self.bt_del.setFixedWidth(self.BUTTON_WIDTH)
        layout.addWidget(self.bt_del)
        self.bt_add = QtWidgets.QPushButton(self)
        self.bt_add.setText("+")
        self.bt_add.setToolTip("Add selected object(s) to this layer.")
        self.bt_add.setFixedWidth(self.BUTTON_WIDTH)
        layout.addWidget(self.bt_add)
        self.bt_sel = QtWidgets.QPushButton(self)
        self.bt_sel.setText("Sel")
        self.bt_sel.setToolTip("Select object(s) from this layer.")
        self.bt_sel.setFixedWidth(self.BUTTON_WIDTH * 2)
        layout.addWidget(self.bt_sel)

        self.setLayout(layout)

    def set_name(self, name):
        self.name = name
        self.lb_name.setText(name)

    def set_status(self, status):
        self.status = status
        if status == "all":
            self.ck_status.setCheckState(QtCore.Qt.CheckState.Checked)
        elif status == "none":
            self.ck_status.setCheckState(QtCore.Qt.CheckState.Unchecked)
        else:
            self.ck_status.setCheckState(QtCore.Qt.CheckState.PartiallyChecked)

    def connect_delete(self, callback):
        self.bt_del.clicked.connect(callback)

    def connect_add(self, callback):
        self.bt_add.clicked.connect(callback)

    def connect_select(self, callback):
        self.bt_sel.clicked.connect(callback)

class KuesaLayersUi (QtWidgets.QDialog):

    layout_main = None
    list_layers = None
    edit_name = None
    lb_message = None
    lb_message_sign = None

    block_count = None

    def __init__(self, parent=MaxPlus.GetQMaxMainWindow()):
        super(KuesaLayersUi, self).__init__(parent)
        self.setWindowTitle('Kuesa Layer Manager')
        self.layout_main = QtWidgets.QVBoxLayout(self)

        bt_refresh = QtWidgets.QPushButton(self)
        bt_refresh.setText("Refresh")
        bt_refresh.setToolTip("Refreshes the list and all layer status according to current selection.")
        bt_refresh.clicked.connect(self.callback_refresh)
        self.layout_main.addWidget(bt_refresh)
        self.list_layers = QtWidgets.QListWidget(self)
        self.list_layers.currentItemChanged.connect(self.callback_row_selected)
        self.layout_main.addWidget(self.list_layers)
        self.edit_name = QtWidgets.QLineEdit(self)
        self.edit_name.setToolTip("Shows the name of the selected Layer. Edit this for new layers and for renaming existing layers.")
        self.layout_main.addWidget(self.edit_name)

        layout_buttons = QtWidgets.QHBoxLayout(self)
        bt_new = QtWidgets.QPushButton(self)
        bt_new.setText("New")
        bt_new.setToolTip("Creates a new layer with the name specified above and attaches it to selected object(s).")
        bt_new.clicked.connect(self.callback_new)
        layout_buttons.addWidget(bt_new)
        bt_rename = QtWidgets.QPushButton(self)
        bt_rename.setText("Rename")
        bt_rename.setToolTip("Renames selected layer as specified above.")
        bt_rename.clicked.connect(self.callback_rename)
        layout_buttons.addWidget(bt_rename)
        self.layout_main.addLayout(layout_buttons)

        layout_message = QtWidgets.QHBoxLayout(self)
        self.lb_message = QtWidgets.QLabel(self)
        self.lb_message.setAlignment(QtCore.Qt.AlignRight)
        layout_message.addWidget(self.lb_message)
        self.lb_message_sign = QtWidgets.QLabel(self)
        self.lb_message_sign.setFixedWidth(24)
        self.lb_message_sign.setAlignment(QtCore.Qt.AlignCenter)
        layout_message.addWidget(self.lb_message_sign)
        self.layout_main.addLayout(layout_message)

        self.setLayout(self.layout_main)
        self.show()

        self.block_count = 0;

        self.callback_refresh()

        #todo: do we need callbacks for new scene, selection, etc.?

        self.finished.connect(self.callback_close_dialog)

    # main callbacks

    def callback_close_dialog(self):
        pass

    def callback_refresh(self):
        self.block()
        self.clear_items()
        all_layer_names = pymxs.runtime.KuesaLayers(inAllNodes=True, getLayers=True)
        for layer_name in all_layer_names:
            status = pymxs.runtime.KuesaLayers(inSelectedNodes=True, haveLayer=layer_name)
            self.add_item(layer_name, status)
        self.unblock()
        self.msg_ok()

    def callback_row_selected(self, item):
        self.block()
        self.edit_name.setText(item.layer_item_widget.name)
        self.unblock()

    def callback_delete(self):
        self.block()
        item = self.list_layers.currentItem()
        if item is None:
            self.msg_err("Select a layer first!")
        else:
            widget = item.layer_item_widget
            name = widget.name
            pymxs.runtime.KuesaLayers(inAllNodes=True, delLayer=name)
            self.callback_refresh()
            self.msg_ok("KuesaLayer '{}' removed.".format(name))
        self.unblock()

    def callback_new(self):
        self.block()
        name = self.get_new_layer_name()
        if len(name) == 0:
            self.msg_err("Specify a name first!")
        elif MaxPlus.SelectionManager.GetCount() <= 0:
            self.msg_err("Select target object(s) first!")
        elif name in pymxs.runtime.KuesaLayers(inAllNodes=True, getLayers=True):
            self.msg_err("KuesaLayer '{}' already exists.".format(name))
        else:
            pymxs.runtime.KuesaLayers(inSelectedNodes=True, addLayer=name)
            self.callback_refresh()
            self.msg_ok("Created and attached '{}'.".format(name))
        self.unblock()

    def callback_rename(self):
        self.block()
        item = self.list_layers.currentItem()
        if item is None:
            self.msg_err("Select a layer first!")
        else:
            widget = item.layer_item_widget
            old_name = widget.name
            new_name = self.get_new_layer_name()
            if len(new_name) == 0 or new_name == old_name:
                self.msg_err("Specify a new name first!")
            else:
                pymxs.runtime.KuesaLayers(inAllNodes=True, replaceLayer=old_name, replaceBy=new_name)
                self.callback_refresh()
                self.msg_ok("Replaced '{}' by '{}'.".format(old_name, new_name))
        self.unblock()

    # helpers

    def block(self):
        self.block_count += 1
        if self.block_count == 1:
            self.list_layers.currentItemChanged.disconnect()
            self.setEnabled(False)

    def unblock(self):
        self.block_count -= 1
        if self.block_count == 0:
            self.list_layers.currentItemChanged.connect(self.callback_row_selected)
            self.setEnabled(True)

    def msg_ok(self, text = ""):
        self.lb_message.setText(text)
        self.lb_message_sign.setText("OK")
        self.lb_message_sign.setToolTip("Shows the status of the KuesaLayer manager. Everything is okay.")
        self.lb_message_sign.setStyleSheet("QLabel { background-color: green; color:white }")

    def msg_err(self, text = "ERR"):
        self.lb_message.setText(text)
        self.lb_message_sign.setText("!!")
        self.lb_message_sign.setToolTip("Something went wrong: {}".format(text))
        self.lb_message_sign.setStyleSheet("QLabel { background-color: red; color:white }")

    def clear_items(self):
        self.list_layers.clear()

    def add_item(self, layer_name, status):
        item_widget = LayerItemWidget()
        item_widget.set_name(layer_name)
        item_widget.set_status(status)
        item_widget.connect_delete(lambda: self.callback_item_delete(layer_name))
        item_widget.connect_add(lambda: self.callback_item_add(layer_name))
        item_widget.connect_select(lambda: self.callback_item_select(layer_name))
        item = QtWidgets.QListWidgetItem(self.list_layers)
        item.layer_item_widget = item_widget
        self.list_layers.addItem(item)
        self.list_layers.setItemWidget(item, item_widget)

    def get_new_layer_name(self):
        name = str(self.edit_name.text())
        name = name.replace(" ", "_")
        name = name.replace(",", "_")
        name = name.replace(";", "_")
        self.edit_name.setText(name)
        return name

    # item callbacks

    def callback_item_delete(self, layer_name):
        self.block()
        if MaxPlus.SelectionManager.GetCount() <= 0:
            self.msg_err("Select objet(s) first!")
        else:
            num_before = len(pymxs.runtime.KuesaLayers(getObjectsWithLayer=layer_name))
            pymxs.runtime.KuesaLayers(inSelectedNodes=True, delLayer=layer_name)
            num_after = len(pymxs.runtime.KuesaLayers(getObjectsWithLayer=layer_name))
            self.callback_refresh()
            self.msg_ok("'{}' removed from {} object(s).".format(layer_name, num_before-num_after))
        self.unblock()

    def callback_item_add(self, layer_name):
        self.block()
        if MaxPlus.SelectionManager.GetCount() <= 0:
            self.msg_err("Select objet(s) first!")
        else:
            num_before = len(pymxs.runtime.KuesaLayers(getObjectsWithLayer=layer_name))
            pymxs.runtime.KuesaLayers(inSelectedNodes=True, addLayer=layer_name)
            num_after = len(pymxs.runtime.KuesaLayers(getObjectsWithLayer=layer_name))
            self.callback_refresh()
            self.msg_ok("'{}' added to {} object(s).".format(layer_name, num_after-num_before))
        self.unblock()

    def callback_item_select(self, layer_name):
        self.block()
        pymxs.runtime.KuesaLayers(selectWithLayer=layer_name)
        self.callback_refresh()
        self.msg_ok("{} object(s) selected with '{}'.".format(MaxPlus.SelectionManager.GetCount(), layer_name))
        self.unblock()

if __name__ == "__main__":
    KuesaLayersUi()
