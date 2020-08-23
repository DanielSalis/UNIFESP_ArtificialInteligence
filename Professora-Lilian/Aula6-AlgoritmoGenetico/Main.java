import java.util.Scanner;

public class Main {
    int testCases;
    int bits;
    int cutPosition;
    float mutationProbability;
    int[] firstIndividual;
    int[] secondIndividual;
    int[] expectedIndividual;

    public void setInputs() {
        Scanner s = new Scanner(System.in);
        this.testCases = s.nextInt();
        this.bits = s.nextInt();
        this.cutPosition = s.nextInt();
        this.mutationProbability = s.nextFloat();

        this.firstIndividual = new int[bits];
        this.secondIndividual = new int[bits];
        this.expectedIndividual = new int[bits];

        String strI = s.next();
        String strII = s.next();
        String strIII = s.next();

        int i;
        for (i = 0; i < bits; i++) {
            firstIndividual[i] = Character.getNumericValue(strI.charAt(i));
            secondIndividual[i] = Character.getNumericValue(strII.charAt(i));
            expectedIndividual[i] = Character.getNumericValue(strIII.charAt(i));
        }
    }

    public void printInputs() {
        System.out.println("----------");
        System.out.println(this.testCases);
        System.out.println(this.bits);
        System.out.println(this.cutPosition);
        System.out.println(this.mutationProbability);
        System.out.println("----------");
    }

    public static void main(String[] args) {
        Main m = new Main();
        m.setInputs();
        m.printInputs();
    }
}