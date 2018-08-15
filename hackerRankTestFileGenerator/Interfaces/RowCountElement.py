from random import *

class RowCountElement:
    data = 0

    def __init__(self, ceiling: int):
        if ceiling > 1:
            self.data = randint(1, ceiling)
        else:
            self.data = randint(1, 100)


    def SetRowCount(self, numOfRows: int) :
        self.data = numOfRows

    def GetRowCount(self) ->int:
        return self.data
