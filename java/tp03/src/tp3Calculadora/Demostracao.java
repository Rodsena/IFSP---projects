package tp3Calculadora;

import java.awt.GridLayout;

public class Demostracao {

	
	public static void main(String[] args) {
		
		Calculadora cal = new Calculadora ("TP03 - Calculadora",250, 300,100,100);
		cal.setLayout(new GridLayout(6,4));
		cal.setVisible(true);
	}
}
