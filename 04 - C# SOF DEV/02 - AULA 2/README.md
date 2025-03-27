# Aula de Programação orientada a Objetos

- Revisao sobre implementação do C#

## Conteudo

### Modificadores de acesso

Definem a visibilidade de atributos a metodos dentro do codigo

<table>
    <thead>
        <tr>
            <th>Modificador</th>
            <th>Descrição</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>public</td>
            <td>atributo ou metodo pode ser acessado de qualquer parrte do codigo</td>
        </tr>
        <tr>
            <td>private</td>
            <td>Só pode ser acessado dentro da propia classe</td>
        </tr>
        <tr>
            <td>protected</td>
            <td>Permite acesso apenas dentro da classe e de suas subclasses</td>
        </tr>
        <tr>
            <td>Internal</td>
            <td>...</td>
        </tr>
    </tbody>
</table>

</br>

### Encapsulamento e propiedades

O encapsulamento restringe o acesso direto aos atributos e os protege ocm propiedades. Ele garante que os dados sejam anipulados de forma segura e occntrolada.

```C#
    class Carro {
        private int velocidade;

        public int Velocidade {
            get {return velocidade;}
            set {
                if (value >= 0) velocidade = value; //impede valores negativos para o nosso carro
            }
        }
    }

    Carro meuCarro = new Carro();
    meuCarro.Velocidade = -50;
```

Propiedade automática:
```C#
    class Carro {
        public int Velocidade { get; set; } //só pode ser definido no momento da criação do objeto
    }

```

propiedade com extenção:
```C#
    class Carro {
        private int velocidade;
        private int Velocidade {
            get => velocidade;
            set => velocidade value >= 0 ? value : 0; //validação simplificado
        }
    }
```

propiedade com valor padrao:
```C#
    class Carro {
        public int Velocidade { get; set; } = 10;
    }

```

### Contrutores e destrutores

os contrutores sao metodos especiais de uma classe que sao automaticamente chamados quando um objeto é criado

```C#

    class Carro {
        public string Modelo;
        public int Ano;

        //construtor personalizado
        public Carro(string modelo, int ano){
            string Modelo = modelo;
            int Ano = ano;
        }
    }
```
Construtor primario
```C#

    class Carro(string modelo, int ano){
        public string Modelo { get; set; } = Modelo;
        public int Ano { get; set; } = Ano;
    }
```


## Hands on

- Crie classes para um sistema de controle de estacionamento
- Considere informações como tipo de veículo, marca, modelo, cor e placa
- Proponha classes para o gerenciamento de clientes serviços e pagamentos