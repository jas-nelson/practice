from random import *

class RandomRangedValueList:
    rangedList = list()
    numOfElements = None

    def __init__(self, floor: int, ceiling: int, numOfElem: int):
        self.numOfElements = numOfElem
        for i in range(0, numOfElem):
            self.rangedList.append(randint(floor, ceiling))

    def GenerateNewRangedList(self, floor: int, ceiling: int, numOfElem: int):
        self.numOfElements = numOfElem
        for i in range(0, numOfElem):
            self.rangedList.append(randint(floor, ceiling))