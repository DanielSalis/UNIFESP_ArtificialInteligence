import java.util.Scanner;
import java.util.Arrays;

public class Main {
    int set = 0;
    int par = 0;
    int[] cards = { -1, -1, -1 };

    public void execGame() {
        Scanner s = new Scanner(System.in);
        while (cards[0] != 0 && cards[1] != 0 && cards[2] != 0) {

            this.setInputs(s);

            if (cards[0] == 0 || cards[1] == 0 || cards[2] == 0) {
                break;
            }

            Arrays.sort(this.cards);
            this.set = 0;
            this.par = 0;

            if (cards[0] == cards[1] && cards[1] == cards[2]) {
                set = 1;
            } else if (cards[0] == cards[1] || cards[1] == cards[2]) {
                par = 1;
            }

            this.compare(this.cards, this.set, this.par);
        }

        s.close();
    }

    public void setInputs(Scanner s) {
        cards[0] = s.nextInt();
        cards[1] = s.nextInt();
        cards[2] = s.nextInt();
    }

    public void compare(int[] cards, int set, int par) {
        String array_padrao = "1 1 2";
        int c0;
        int c1;
        int c2;

        if (set == 1) {
            if (cards[0] == 13) {
                System.out.println("*");
            } else {
                c1 = cards[0] + 1;
                System.out.println(c1 + " " + c1 + " " + c1);
            }
        } else if (par == 1) {
            if (cards[0] == cards[1]) {
                if (cards[2] == 13) {
                    System.out.println(1 + " " + ++cards[0] + " " + cards[0]);
                } else {
                    c2 = cards[2] + 1;
                    System.out.println(cards[0] + " " + cards[0] + " " + c2);
                }
            } else {
                if (cards[2] == 13) {
                    if (cards[0] == 12) {
                        System.out.println("1 1 1");
                    } else {
                        c0 = cards[0] + 1;
                        System.out.println(c0 + " " + cards[1] + " " + cards[1]);
                    }
                } else {
                    if (cards[0] + 1 == cards[1]) {
                        c2 = cards[0] + 2;
                        System.out.println(cards[1] + " " + cards[1] + " " + c2);
                    } else {
                        c0 = cards[0] + 1;
                        System.out.println(c0 + " " + cards[1] + " " + cards[1]);
                    }
                }
            }
        } else {
            System.out.println(array_padrao);
        }

    }

    public static void main(String[] args) {
        Main m = new Main();
        m.execGame();
    }
}