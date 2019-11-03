package tp03versao2;



public class Pessoa {
	
	//atributos
	
	protected static int kp = 0;
	protected String nome;
	protected char sexo;
	protected int idade;
	
	//construtores
	
	
	
	
	public Pessoa(String nome, char sexo, int idade) {
		super();
		this.nome = nome;
		this.sexo = sexo;
		this.idade = idade;
	}
	
	
	
	public Pessoa() {
		
	}

	//Propriedades
	
	public static int getKp() {
		return kp;
	}
	public static void setKp(int kp) {
		Pessoa.kp = kp;
	}
	public String getNome() {
		return nome;
	}
	public void setNome(String nome) {
		this.nome = nome;
	}
	public char getSexo() {
		return sexo;
	}
	public void setSexo(char sexo) {
		this.sexo = sexo;
	}
	public int getIdade() {
		return idade;
	}
	public void setIdade(int idade) {
		this.idade = idade;
	}
	
	//métodos
	
	public static int geraKp() {
		return kp++;
	}
	
	
}
