
import java.util.*;

public class Aaah {

	public static void main(String args[]) {
		Scanner f =  new Scanner(System.in);
		
		String first = f.nextLine();
		String second = f.nextLine();
		
		if(first.length() >= second.length()) {
			System.out.println("go");
		}
		else {
			System.out.println("no");
		}
		f.close();
	}
}
