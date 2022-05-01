from collections import deque

class Game:
    def __init__(self):
        self.initialState = State.getInitialState()
        self.statesQueue = deque()
        self.visitedStates = set()
        self.solutions = list()

    def printSolution(self):
        current_state = self.solutions[0]
        counter = 0
        while current_state:
            if(counter % 2 != 0):
                print('Indo')        
            else:
                print('Voltando')
            print(current_state.variables)
            
            counter += 1
            current_state = current_state.parent

class State:
    def __init__(self, variables, movements=0, parent=None):
        self.variables = variables
        self.movements = movements
        self.parent = parent

    @classmethod
    def getInitialState(self):
        return self((3,3,1))
    
    def verifyState(self):
        m = self.variables[0]
        c = self.variables[1]
        
        if m < 0 or m > 3: 
            return False
        elif c < 0 or c > 3:
            return False
        else:
            return True
        
    def foundSolution(self):
        if self.variables == (0,0,0):
            return True
        return False
    
    def getNextStates(self):
        possibleMoves = [(1, 0), (2, 0), (0, 1), (0, 2), (1, 1)];
        nextStates = list()
        missOnTheRight, canOnTheLeft, moving = self.variables
        
        for move in possibleMoves:
            changeMiss, changeCan = move
            if moving == 1:
                new_variables = (missOnTheRight-changeMiss, canOnTheLeft-changeCan, 0)
            else:
                new_variables = (missOnTheRight+changeMiss, canOnTheLeft+changeCan, 1)
            
            new_state = State(new_variables, self.movements+1, self)
            
            if new_state.verifyState():
                nextStates.append(new_state)

        return nextStates

    def fail(self):
        miss = self.variables[0]
        can = self.variables[1]

        if miss > 0 and miss < can:
            return True
        
        miss_on_left = 3 - miss
        can_on_left = 3 - can
        if miss_on_left > 0 and miss_on_left < can_on_left:
            return True

        return False


def BFS():

    game = Game()
    game.statesQueue.append(game.initialState)
        
    
    while game.statesQueue:
    
        currentState = game.statesQueue.pop()
        nextStates = currentState.getNextStates()
        
        for possibleState in nextStates:
            
            state = possibleState.variables
            
            if state not in game.visitedStates:
                
                if possibleState.fail():
                    print("Falhou!")
                    continue

                if possibleState.foundSolution():
                    game.solutions.append(possibleState)
                    continue
                       
                game.statesQueue.append(possibleState)
                game.visitedStates.add(state)
                
    game.printSolution()

BFS()