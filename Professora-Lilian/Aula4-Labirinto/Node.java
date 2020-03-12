import java.util.ArrayList;
import java.util.List;

public class Node {
    public int value;
    public List<Node> neighbours;
    public boolean visited;

    Node(int newValue){
        value = newValue;
        neighbours = new ArrayList<>();
    }

    public void addNewNeighbour(Node neighbour){
        neighbours.add(neighbour);
    }

    public List<Node> getNeighbours() {
        return neighbours;
    }

    public void setNeighbours(List<Node> newNeighbours) {
        neighbours = newNeighbours;
    }

}