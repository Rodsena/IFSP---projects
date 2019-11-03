package tp03Versao3;

import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.*;
import javax.swing.UIManager.LookAndFeelInfo;

public class Form1 extends JFrame implements ActionListener {
	
	int numKp = 0;
	String nome = "";
	char sexo;
	int idade;
	
	
	JLabel lbNum = new JLabel("Numero: ");
	JTextField campoNum = new JTextField(20);
	JLabel lbNome = new JLabel("Nome: ");
	JTextField campoNome = new JTextField(20);
	JLabel lbSexo = new JLabel("Sexo: ");
	
	ButtonGroup grupoRadio = new ButtonGroup();
	JRadioButton sexoRadioM = new JRadioButton();
	JRadioButton sexoRadioF = new JRadioButton();
	
	JLabel lbIdade = new JLabel("Idade: ");
	JTextField campoIdade = new JTextField(20);
	
	JButton btnOk = new JButton("OK");	
	JButton btnLimpar = new JButton("Limpar");
	JButton btnMostrar = new JButton("Mostrar");	
	JButton btnSair = new JButton("Sair");
	
	Pessoa UmaPessoa;
	
	
	
	Form1(String titulo, int largura, int altura, int colinic, int lininic)
	{
		super(titulo);
		setSize(largura, altura);
		setLocation(colinic, lininic);
	
	
		JPanel Dados = new JPanel();
		Dados.setLayout(new GridLayout(4,2));
		
		JPanel DadosSexo = new JPanel();
		DadosSexo.setLayout(new GridLayout(1,2));
		
		campoNum.setEnabled(false);
		campoNome.setInputVerifier(null);
		
		JPanel Button = new JPanel();
		Button.setLayout(null);
		
		sexoRadioF.setActionCommand("F");
		sexoRadioF.setText("F");
		sexoRadioM.setActionCommand("M");
		sexoRadioM.setText("M");
		
		grupoRadio.add(sexoRadioM);
		grupoRadio.add(sexoRadioF);
		
		DadosSexo.add(sexoRadioF);
		DadosSexo.add(sexoRadioM);
		
		Dados.add(lbNum);
		Dados.add(campoNum);
		Dados.add(lbNome);
		Dados.add(campoNome);
		Dados.add(lbSexo);		
		Dados.add(DadosSexo);	
		Dados.add(lbIdade);
		Dados.add(campoIdade);
		
		Button.add(btnOk);
		btnOk.setBounds(1,20,100,50);
		Button.add(btnLimpar);
		btnLimpar.setBounds(101,20,100,50);
		Button.add(btnMostrar);
		btnMostrar.setBounds(201,20,100,50);
		Button.add(btnSair);
		btnSair.setBounds(301,20,100,50);
		
		add(Dados);
		add(Button);
		
	
		btnOk.addActionListener(this);
		btnLimpar.addActionListener(this);
		btnMostrar.addActionListener(this);
		btnSair.addActionListener(this);

	
	}
	public static void main(String[]args){
		
		Form1 f = new Form1("TP03 - Exercicio 2 - V3", 418, 250,100,100);
		f.setLayout(new GridLayout(2,1));
		f.setVisible(true);
		
		try {
		    for (LookAndFeelInfo info : UIManager.getInstalledLookAndFeels()) {
		        if ("Windows Vista".equals(info.getName())) {
		            UIManager.setLookAndFeel(info.getClassName());
		            break;
		        }
		    }
		} catch (UnsupportedLookAndFeelException e) {
		    // handle exception
		} catch (ClassNotFoundException e) {
		    // handle exception
		} catch (InstantiationException e) {
		    // handle exception
		} catch (IllegalAccessException e) {
		    // handle exception
		}
	}
	
	@Override
	public void actionPerformed(ActionEvent e) {
		if(e.getSource() == btnOk) {
			
			if(campoNome.getText().equalsIgnoreCase("") || campoIdade.getText().equals("")) 
				
				JOptionPane.showMessageDialog(rootPane,"Por favor informe os Dados primeiro","Erro - Campo Vazio", JOptionPane.ERROR_MESSAGE, null);
			
			else if(grupoRadio.isSelected(null)){
				
				JOptionPane.showMessageDialog(rootPane,"Por favor escolha o sexo com M = masculino ou F = feminino!","Erro - Campo Sexo", JOptionPane.ERROR_MESSAGE, null);
			}
				
			else if (sexoRadioF.isSelected()){
				numKp = Pessoa.geraKp();
				nome = campoNome.getText();
				sexo = sexoRadioF.getActionCommand().charAt(0);
				idade = Integer.parseInt(campoIdade.getText());
				
				UmaPessoa = new Pessoa (nome, sexo, idade);	
				
			}
			else {
				numKp = Pessoa.geraKp();
				nome = campoNome.getText();
				sexo = sexoRadioM.getActionCommand().charAt(0);
				idade = Integer.parseInt(campoIdade.getText());
				
				UmaPessoa = new Pessoa (nome, sexo, idade);	
			}
	}
				
		if(e.getSource() == btnLimpar) {
			
			campoNum.setText("");
			campoNome.setText("");
			grupoRadio.clearSelection();
			campoIdade.setText("");
		}
		if(e.getSource() == btnMostrar) {
		
				campoNum.setText(Integer.toString(UmaPessoa.kp));
				campoNome.setText(UmaPessoa.getNome());
				if(Character.toString(UmaPessoa.getSexo()).equals(sexoRadioF.getActionCommand())) {
					sexoRadioF.setSelected(true);
				}
				else
					sexoRadioM.setSelected(true);
									
				campoIdade.setText(Integer.toString(UmaPessoa.getIdade()));
		}
		if(e.getSource() == btnSair) {
			System.exit(0);
		}
	} 
}
