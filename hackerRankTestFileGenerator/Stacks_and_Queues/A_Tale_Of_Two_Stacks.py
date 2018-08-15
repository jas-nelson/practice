import os
import logging
from Interfaces import RowCountElement, CommandElement
from random import *

class TaleOfTwoStacks_TestFile:
    logger = logging.getLogger(name="TaleOfTwoStacks_TestFile_Logger")
    rowCount = None
    rows = []

    def __init__(self):
        self.rowCount = RowCountElement.RowCountElement(ceiling=10000)
        self.rows = self.GenerateRows()

    def GenerateRows(self):
        # generate rows
        localRows = list()
        for row in range(0, self.rowCount.GetRowCount()):
            localRows.append(CommandElement.CommandElement(floor=1, ceiling=3, dataVal=randint(1, 1000)))
        return localRows

    def GenerateFile(self, filePath):
        cd = os.curdir
        savePath = os.path.join(cd, filePath)

        with open(savePath, "w") as file:

            file.write(str(self.rowCount.GetRowCount()))

            for row in self.rows:
                file.write("\n")
                cmdType = row.commandType

                if cmdType == 1:
                    file.write(str(row.commandType) + " " + str(row.data))
                elif cmdType == 2 or cmdType == 3:
                    file.write(str(row.commandType))
                else:
                    self.logger.error(msg="GenerateFile: CommandElement.CommandType value out of range.")


# program code to generate file.
fileName = "tale_of_two_stacks_testFile.txt"

testFile = TaleOfTwoStacks_TestFile()
testFile.GenerateFile(filePath=fileName)



