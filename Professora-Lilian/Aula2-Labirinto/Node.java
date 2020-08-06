import java.util.ArrayList;
import java.util.List;

public class Node {
    public int positionX;
    public int positionY;
    public int value;
    public List<Node> neighbours;
    public boolean visited;

    Node(int newValue, int x, int y){
        value = newValue;
        neighbours = new ArrayList<>();
        positionX = x;
        positionY = y;
    }

    public void addNewNeighbour(Node neighbour){
        neighbours.add(neighbour);
    }

    public List<Node> getNeighbours() {
        return neighbours;
    }

    public void printNodeNeighbours(){
        for (Node obj : neighbours) {
            System.out.print(obj.getValue() + " ");
        }
        System.out.println();
    }

    public void setNeighbours(List<Node> newNeighbours) {
        neighbours = newNeighbours;
    }

    public int getValue() {
        return value;
    }

    public int[] getPositions(){
        int []positions = new int[2];
        positions[0] = positionX;
        positions[1] = positionY;
        return positions;
    }
}