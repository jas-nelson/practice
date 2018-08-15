from random import randint
from Interfaces import RandomRangedValueList
import logging
import os

class LargestRectangle_TestFile:
    buildings = None
    logger = logging.getLogger("LargestRectangle_TestFile_Logger")

    def __init__(self):
        self.buildings = RandomRangedValueList.RandomRangedValueList(floor=1,
                                                                     ceiling=100000,
                                                                     numOfElem=randint(1, 1000000))


    def GenerateFile(self, fileName):

        cd = os.curdir
        savePath = os.path.join(cd, fileName)

        with open(savePath, "w") as file:

            file.write(str(self.buildings.numOfElements) + "\n")
            file.write(" ".join(str(x) for x in self.buildings.rangedList))

            file.close()


fileName = "largestRectangle_testFile.txt"
testFile = LargestRectangle_TestFile()
testFile.GenerateFile(fileName=fileName)
