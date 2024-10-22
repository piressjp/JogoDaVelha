# Jogo da Velha - C# / Windows Forms

Este é um projeto de **Jogo da Velha** desenvolvido em **C#** utilizando o **Windows Forms** com a arquitetura **MVP** (Model-View-Presenter). O jogo permite jogar entre dois jogadores locais ou contra a máquina (1 x Machine).

## Funcionalidades

- Modo de jogo **1 vs 1**: Dois jogadores humanos podem jogar no mesmo dispositivo.
- Modo de jogo **vs Machine**: Um jogador humano pode jogar contra a máquina (com jogadas aleatórias).
- Detecção automática de vencedores e empates.
- Opção de reiniciar o jogo após o término de uma partida.

## Estrutura do Projeto

O projeto foi estruturado utilizando o padrão **MVP (Model-View-Presenter)**, separando a lógica do jogo (model) da interface gráfica (view) e dos controladores de interação (presenters). Isso facilita a manutenção, teste e escalabilidade do projeto.

## Componentes do Projeto
### Models:

- GameModel.cs: Contém toda a lógica de negócio do jogo, como verificar o estado do tabuleiro, a lógica de turno e a verificação de vitória ou empate.

### Views:

- IGameView.cs: Interface para a view do jogo (GameForm), que define os métodos necessários para atualizar a interface.
- IStartView.cs: Interface para a view inicial (StartForm), que define como a navegação para o jogo deve ocorrer.
- GameForm.cs: Implementação da interface gráfica do jogo (o tabuleiro de 3x3, status de jogo, etc.).
- StartForm.cs: Implementação da tela inicial com opções para selecionar o modo de jogo.

### Presenters:

- GamePresenter.cs: Contém a lógica que conecta o GameModel à GameView, manipulando as jogadas do jogador, a máquina e verificando o resultado da partida.
- StartPresenter.cs: Controla a navegação entre a tela inicial e a tela do jogo, gerenciando os modos de jogo.

## Executar o Projeto

### Pré-requisitos

- .NET SDK 6.0
- Um editor compatível com .NET, como o Visual Studio ou Visual Studio Code com suporte ao C#.

### Passos para execução

1. Clone este repositório para sua máquina local:

``` bash
https://github.com/piressjp/JogoDaVelha.git
```
2. Abra o projeto no Visual Studio ou no editor de sua preferência.

3. Restaure os pacotes NuGet (se necessário):

```bash
dotnet restore
```
4. Compile e execute o projeto:

```bash
dotnet run
```

## Contribuições
Contribuições são bem-vindas! Sinta-se à vontade para abrir um Pull Request ou reportar Issues.

## Melhorias Futuras

- IA Melhorada: Atualmente, a máquina faz movimentos aleatórios. Uma possível melhoria seria implementar uma IA mais inteligente, como o algoritmo Minimax.
- Testes Unitários: Adicionar testes unitários para garantir a integridade das regras do jogo.
- Design: Melhorar a interface gráfica para torná-la mais atraente e intuitiva.
