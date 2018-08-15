from random import *

class CommandElement:
    commandType = None
    data = None

    def __init__(self, floor: int, ceiling: int, dataVal):
        self.commandType = randint(floor, ceiling)
        self.data = dataVal


    def setCommandType(self, cmdType: int) :
        self.commandType = cmdType

    def setData(self, dataVal):
        self.data = dataVal