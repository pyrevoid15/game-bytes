import os, sys
import json
from tkinter import *

try:
    from PIL import Image, ImageTk, ImageDraw, ImageFont
except ModuleNotFoundError:
    print("You are missing a necessary module - PIL.")

class Application():
    def __init__(self) -> None:
        self.file_targ = ""
        self.open_file = None
        self.working_str = ""
        self.bpm = 4
        self.time_windows = {
            "ok": 0.3,
            "good": 0.2,
            "excellent": 0.1
        }
        self.instrument_mode = "drum"
        self.drumApproachTime = 1.0
        self.guitarApproachTime = 2.0
        self.numNotesDrum = 0
        self.numNotesGuitar = 0
        self.noteLocationsDrum = []
        self.noteLocationsGuitar = []
        self.noteTimesDrum = []
        self.noteTimesGuitar = []
        self.available_levels = []

        self.left_mode = "none"
        self.right_mode = "none"

    def save():
        pass

    def load():
        pass

class Window(PanedWindow):
    def __init__(self, master=None) -> None:
        super().__init__(master, orient=VERTICAL)
        self.w_w = 800
        self.w_h = 700
        self.master.geometry("800x700+0+0")
        self.master.title("Charter")
        self.info = Application()

        self.up_pane = LabelFrame(self, bg="#0f0f0f", height=23, width=self.w_w)
        self.add(self.up_pane)

        self.working_area = PanedWindow(self, bg="#3f3f3f", height=self.w_h-23, width=self.w_w)
        self.add(self.working_area)
        self.options = LabelFrame(self, bg="#0f0f0f", height=self.w_h - 10, width=self.w_w // 4)
        self.chartview = Canvas(self, bg="#eeeeee", height=self.w_h - 10, width=self.w_w // (4 / 3))
        self.working_area.add(self.options)
        self.working_area.add(self.chartview)

        self.menu_buttons = {
            "file": [Button(self.up_pane, text="FILE", activeforeground="#eeeeee",
                 activebackground="#5f5f5f", height=1, width=5,
                 bg="#0f0f0f", fg="#ffffff", command=self.doFileMenu),
             (0, 0)],
            "edit": [Button(self.up_pane, text="EDIT", activeforeground="#eeeeee",
                activebackground="#5f5f5f", height=1, width=5,
                bg="#0f0f0f", fg="#ffffff", command=self.doEditMenu),
             (0, 1)],
            "help": [Button(self.up_pane, text="ABOUT", activeforeground="#eeeeee",
                activebackground="#5f5f5f", height=1, width=5,
                bg="#0f0f0f", fg="#ffffff", command=self.doAboutMenu),
             (0, 2)],
        }

        for b in self.menu_buttons.values():
            b[0].place(relheight=1.0, relwidth=0.05, relx=b[1][1] * 0.06 + 0.02, rely=b[1][0] * 0)
            
        self.emptyMenu()
        self.pack()

        #relevant variables
        self.file_name = StringVar(self.options)

    def emptyMenu(self):
        self.title = Text(self.options, bg="#0f0f0f", fg="#ffffff", relief=FLAT)
        self.title.insert(INSERT, "Select FILE to begin.")
        self.title.place(rely=0.05, relx=0.06, relwidth=0.88, relheight=0.05)

    def unemptyMenu(self):
        self.title.destroy()

    def doFileMenu(self):
        if self.info.left_mode == "file":
            self.leaveFileMenu()
            self.emptyMenu()
            self.info.left_mode = "none"
        else:
            if self.info.left_mode == "none":
                self.unemptyMenu()
            elif self.info.left_mode == "edit":
                self.leaveEditMenu()
            elif self.info.left_mode == "about":
                self.leaveAboutMenu()
            
            self.enterFileMenu()
            self.info.left_mode = "file"

    def enterFileMenu(self):
        self.file_entry_label = Label(self.options, bg="#0f0f0f", fg="#ffffff", text="File Name:")
        self.file_entry = Entry(self.options, fg="#afefef", bg="#3f3f3f", exportselection=0,
         textvariable=self.file_name, width=35)
        self.file_enterer = Button(self.options, bg="#0f0f0f", fg="#0f0f0f",
         height=self.file_entry.winfo_height(), command=self.enterFileName)

        self.file_entry_label.place(relx=0.01, rely=0.05)
        self.file_entry.place(relx=0.2, rely=0.05)
        self.file_enterer.place(relx=0.8, rely=0.05)
        self.working_area.sash_place(0, self.w_w // 2, 0)

        self.open_button = Button(self.options, text="OPEN", bg="#0f0f0f", fg="#3f3f3f")
        self.save_button = Button(self.options, text="SAVE", bg="#0f0f0f", fg="#3f3f3f")

        self.open_button.place(relx=0.3, rely=0.3)
        self.save_button.place(relx=0.6, rely=0.3)

    def leaveFileMenu(self):
        self.file_entry.destroy()
        self.file_entry_label.destroy()
        self.file_enterer.destroy()
        self.working_area.sash_place(0, self.w_w // 3, 0)
    
    def enterFileName(self):
        if self.file_name.get() != "":
            self.info.file_targ = "Charts" + os.sep + self.file_name.get() + ".txt"
        self.master.title(self.master.title() + " - " + self.info.file_targ)

    def doEditMenu(self):
        if self.info.left_mode == "edit":
            self.leaveFileMenu()
            self.emptyMenu()
            self.info.left_mode = "none"
        else:
            if self.info.left_mode == "none":
                self.unemptyMenu()
            elif self.info.left_mode == "file":
                self.leaveFileMenu()
            elif self.info.left_mode == "about":
                self.leaveAboutMenu()
            
            self.enterEditMenu()
            self.info.left_mode = "edit"
    
    def leaveEditMenu(self):
        pass

    def enterEditMenu(self):
        pass

    def doAboutMenu(self):
        if self.info.left_mode == "about":
            self.leaveFileMenu()
            self.emptyMenu()
            self.info.left_mode = "none"
        else:
            if self.info.left_mode == "none":
                self.unemptyMenu()
            elif self.info.left_mode == "edit":
                self.leaveEditMenu()
            elif self.info.left_mode == "file":
                self.leaveFileMenu()
            
            self.enterAboutMenu()
            self.info.left_mode = "about"

    def leaveAboutMenu(self):
        pass

    def enterAboutMenu(self):
        pass


class Main:
    def __init__(self):
        pass


if __name__ == "__main__":
    gui = Tk()
    app = Window(gui)
    app.mainloop()