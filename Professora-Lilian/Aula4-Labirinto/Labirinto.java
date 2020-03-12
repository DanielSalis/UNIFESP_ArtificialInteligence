import java.util.Scanner;

public class Labirinto {
    
    public int lines;
    public int columns;
    public char [][] map;
    public Node[] nodes;

    public char [][]getMaze(){
        Scanner scanner = new Scanner(System.in);
        char [][] maze = new char[lines][columns];
        
        for(int i=0; i<lines;i++){
            for(int j=0; j<columns; j++){
                maze[i][j] = scanner.next().charAt(0);
            }
        }
        
        scanner.close();
        return maze;
    }

    public void printMaze(char[][]maze){
        for(int i=0; i<lines;i++){
            for(int j=0; j<columns; j++){
                System.out.print(maze[i][j] + " ");
            }
            System.out.print("\n");
        }
    }
    
    public void createAdjacencyMatrix(){
        for(int i=0; i< this.lines; i++){
            for(int j=0; j<this.columns; j++){
                if(map[i][j] == '.'){
                    Node newNode  = new Node(i);
                    settingNeighbours(i, j);
                }
            }
        }
    }

    public void settingNeighbours(int i, int j){

    }

    public static void main(String[] args) {
        Labirinto l = new Labirinto();
        Scanner scanner = new Scanner(System.in);

        l.lines = scanner.nextInt();
        l.columns = scanner.nextInt();

        l.map = l.getMaze();
        l.printMaze(l.map);

        scanner.close();
    }
} 