import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.Stack;

public class Labirinto {
    
    public int lines;
    public int columns;
    public char [][] map;
    public List<Node> nodes = new ArrayList<>();

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
    
    public void findAdjacency(){
        int nodeValue = 0;
        for(int i=0; i< this.lines; i++){
            for(int j=0; j<this.columns; j++){
                if(map[i][j] == '.'){
                    Node newNode  = new Node(nodeValue, i, j);
                    nodes.add(newNode);
                }
                nodeValue++;
            }
        }
        settingNeighbours();
    }

    public Node getNode(int nodeValue){
        for (Node node : nodes) {
            if (node.getValue() == (nodeValue)) {
                return node;
            }
        }
        return null;
    }

    public Node getNode(int i, int j){
        for (Node node : nodes) {
            int []positions = node.getPositions();
            if (positions[0] == i && positions[1] == j) {
                return node;
            }
        }
        return null;
    }

    public void settingNeighbours(){
        int nodeValue = 0;
        for(int i=0; i< this.lines; i++){
            for(int j=0; j<this.columns; j++){
                if(map[i][j] == '.'){
                    Node node  = getNode(nodeValue);
                    executeVerifications(node, i, j);
                    // node.printNodeNeighbours();
                }
                nodeValue++;
            }
        }
    }

    public void executeVerifications(Node node, int i, int j){
        verifyLeft(node, i, j);
        verifyRigth(node, i, j);
        verifyTop(node, i, j);
        verifyBottom(node, i, j);
    }

    public boolean verifyLeft(Node node, int i, int j){
        if(j-1 >= 0 && map[i][j-1] == '.'){
            Node neighbour = getNode(i, j-1);
            node.addNewNeighbour(neighbour);
            return true;
        }
        return false;
    }

    public boolean verifyRigth(Node node,int i, int j){
        if(j+1 <= lines-1 && map[i][j+1] == '.'){
            Node neighbour = getNode(i, j+1);
            node.addNewNeighbour(neighbour);
            return true;
        }
        return false;
    }

    public void verifyTop(Node node,int i, int j){
        if(i-1 >= 0 && map[i-1][j] == '.'){
            Node neighbour = getNode(i-1, j);
            node.addNewNeighbour(neighbour);
        }
    }

    public void verifyBottom(Node node,int i, int j){
        if(i+1 <= columns-1 && map[i+1][j] == '.'){
            Node neighbour = getNode(i+1, j);
            node.addNewNeighbour(neighbour);
        }
    }

    public void executeAllDfs(){
        for(Node node : nodes){
            dfs(node);
            for(Node n: nodes){
                n.visited = false;
            }
            System.out.println();
        }
    }

    public void dfs(Node node){
        Stack<Node> stack = new Stack<Node>();
        stack.add(node);
        while(!stack.isEmpty()){
            Node currentNode = stack.pop();
            if(!currentNode.visited){
                System.out.print(currentNode.value + " ");
                currentNode.visited = true;
            }

            List<Node> neighbours = currentNode.getNeighbours();
            for(int i=0; i< neighbours.size(); i++){
                Node visitedNeighbour = neighbours.get(i);
                if(visitedNeighbour != null && !visitedNeighbour.visited){
                    stack.add(visitedNeighbour);
                }
            }
        }
    }

    public void printValidNodes(){
        for (Node obj : nodes) {
            System.out.print(obj.getValue() + " ");
        }
    }

    public static void main(String[] args) {
        Labirinto l = new Labirinto();
        Scanner scanner = new Scanner(System.in);

        l.lines = scanner.nextInt();
        l.columns = scanner.nextInt();

        l.map = l.getMaze();
        l.findAdjacency();
        l.executeAllDfs();
        

        scanner.close();
    }
} 