package tp3Calculadora;

import java.awt.Color;
import java.awt.Dimension;
import java.awt.FlowLayout;
import java.awt.Font;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JFormattedTextField;
import javax.swing.JFrame;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JTextField;
import javax.swing.JTextPane;

public class Calculadora extends JFrame implements ActionListener {

	// VARIAVEIS AUXILIARES
	Double valor = 0.0;
	Double memoria = 0.0;
	Double memoriaM = 1.;
	Boolean Multi = false;
	String operacao = "";

	// CRIANDO TEXTFIELD E BUTTONS
	JTextField cDisplay = new JTextField();

	JButton btnSete = new JButton("7");
	JButton btnOito = new JButton("8");
	JButton btnNove = new JButton("9");
	JButton btnDivisao = new JButton("/");

	JButton btnQuatro = new JButton("4");
	JButton btnCinco = new JButton("5");
	JButton btnSeis = new JButton("6");
	JButton btnMultiplica = new JButton("*");

	JButton btnUm = new JButton("1");
	JButton btnDois = new JButton("2");
	JButton btnTres = new JButton("3");
	JButton btnMenos = new JButton("-");

	JButton btnZero = new JButton("0");
	JButton btnPonto = new JButton(".");
	JButton btnIgual = new JButton("=");
	JButton btnSoma = new JButton("+");

	JButton btnClear = new JButton("C");
	JTextField campoVazio = new JTextField(10);
	JTextField campoVazio1 = new JTextField(10);

	Calculadora(String titulo, int largura, int altura, int colinic, int lininic) {

		super(titulo);
		setSize(largura, altura);
		setLocation(colinic, lininic);

		JPanel Display = new JPanel();
		Display.setLayout(new GridLayout(1, 1));

		cDisplay.setBackground(new Color(245, 245, 245));
		cDisplay.setFont(new Font("Arial", Font.BOLD, 18));
		cDisplay.setForeground(Color.black);
		cDisplay.setHorizontalAlignment(JTextField.RIGHT);
		cDisplay.setEditable(false);

		JPanel Botoes = new JPanel();
		Botoes.setLayout(new GridLayout(1, 4));
		
		JPanel Botoes2 = new JPanel();
		Botoes2.setLayout(new GridLayout(1, 4));

		JPanel Botoes3 = new JPanel();
		Botoes3.setLayout(new GridLayout(1, 4));

		JPanel Botoes4 = new JPanel();
		Botoes4.setLayout(new GridLayout(1, 4));

		JPanel BotoesClear = new JPanel();
		BotoesClear.setLayout(new GridLayout());

		Display.add(cDisplay);

		Botoes.add(btnSete);
		Botoes.add(btnOito);
		Botoes.add(btnNove);
		Botoes.add(btnDivisao);

		Botoes2.add(btnQuatro);
		Botoes2.add(btnCinco);
		Botoes2.add(btnSeis);
		Botoes2.add(btnMultiplica);

		Botoes3.add(btnUm);
		Botoes3.add(btnDois);
		Botoes3.add(btnTres);
		Botoes3.add(btnMenos);

		Botoes4.add(btnZero);
		Botoes4.add(btnPonto);
		Botoes4.add(btnIgual);
		Botoes4.add(btnSoma);

		BotoesClear.add(btnClear);

		add(Display);
		add(Botoes);
		add(Botoes2);
		add(Botoes3);
		add(Botoes4);
		add(BotoesClear);

		btnUm.addActionListener(this);
		btnDois.addActionListener(this);
		btnTres.addActionListener(this);
		btnQuatro.addActionListener(this);
		btnCinco.addActionListener(this);
		btnSeis.addActionListener(this);
		btnSete.addActionListener(this);
		btnOito.addActionListener(this);
		btnNove.addActionListener(this);
		btnZero.addActionListener(this);
		btnDivisao.addActionListener(this);
		btnSoma.addActionListener(this);
		btnMultiplica.addActionListener(this);
		btnMenos.addActionListener(this);
		btnIgual.addActionListener(this);
		btnClear.addActionListener(this);
		btnPonto.addActionListener(this);
	}

	@Override
	public void actionPerformed(ActionEvent e) {
		if (e.getSource() == btnZero) {

			cDisplay.setText(cDisplay.getText() + "0");
		}
		if (e.getSource() == btnUm) {

			cDisplay.setText(cDisplay.getText() + "1");
		}
		if (e.getSource() == btnDois) {

			cDisplay.setText(cDisplay.getText() + "2");
		}
		if (e.getSource() == btnTres) {

			cDisplay.setText(cDisplay.getText() + "3");
		}
		if (e.getSource() == btnQuatro) {

			cDisplay.setText(cDisplay.getText() + "4");
		}
		if (e.getSource() == btnCinco) {

			cDisplay.setText(cDisplay.getText() + "5");
		}
		if (e.getSource() == btnSeis) {

			cDisplay.setText(cDisplay.getText() + "6");
		}
		if (e.getSource() == btnSete) {

			cDisplay.setText(cDisplay.getText() + "7");
		}
		if (e.getSource() == btnOito) {

			cDisplay.setText(cDisplay.getText() + "8");
		}
		if (e.getSource() == btnNove) {

			cDisplay.setText(cDisplay.getText() + "9");
		}
		if (e.getSource() == btnPonto) {

			cDisplay.setText(cDisplay.getText() + ".");
		}
		// OPERADORES
		if (e.getSource() == btnSoma) {

			operacao = "+";
			valor = Double.parseDouble(cDisplay.getText());
			memoria += valor;
			cDisplay.setText("");
		}
		if (e.getSource() == btnMenos) {

			operacao = "-";
			valor = Double.parseDouble(cDisplay.getText());
			if (memoria < valor) {
				memoria = valor - memoria;
			} else
				memoria = memoria - valor;
			cDisplay.setText("");
		}
		if (e.getSource() == btnMultiplica) {

			operacao = "*";
			valor = Double.parseDouble(cDisplay.getText());
			memoriaM *= valor;
			cDisplay.setText("");
		}
		if (e.getSource() == btnDivisao) {

			operacao = "/";
			valor = Double.parseDouble(cDisplay.getText());
			if (memoria == 0.0)
				memoria += valor;
			else
				memoria /= valor;
			cDisplay.setText("");
		}
		// BOTÃO DE LIMPAR
		if (e.getSource() == btnClear) {

			Multi = false;
			memoria = 0.0;
			valor = 0.0;
			cDisplay.setText("0");
		}
		// CASE OPERADORES
		if (e.getSource() == btnIgual) {
			try {
				switch (operacao) {
				case "+":
					memoria += Double.parseDouble(cDisplay.getText());
					break;
				case "-":
					memoria -= Double.parseDouble(cDisplay.getText());
					break;
				case "*":
					memoriaM *= Double.parseDouble(cDisplay.getText());
					Multi = true;
					break;
				case "/":
					memoria /= Double.parseDouble(cDisplay.getText());
					break;

				default:
					break;
				}
			} catch (NumberFormatException erro) {
				JOptionPane.showMessageDialog(rootPane, "Insira pelos menos 1 valor após o operador", "Mau uso", JOptionPane.INFORMATION_MESSAGE);
			} finally {
				cDisplay.setText("");
				
			}
			
			// RESULTADO			
			  valor = 0.0;
			  if(Multi == true) // RESULTADO MULTIPLICAÇÃO
				  cDisplay.setText(memoriaM.toString());
			  else //RESULTADO DOS DEMAIS OPERADORES
				  cDisplay.setText(memoria.toString()); 
			  // ZERANDO A MEMORIA 
			  Multi = false;
			  memoria = 0.0; 
			  memoriaM = 1.;
			 
			 
		}

	}
}
