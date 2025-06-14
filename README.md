# adocao-animais

Desafio desenvolvido para praticar a criação de APIs utilizando Entity Framework (EF) com .NET e arquitetura limpa (Clean Architecture).

## Rotas

- GetAll: `base_url/api/v1/animais`
- Create: `base_url/api/v1/animais`
- Adopt: `base_url/api/v1/animais/{id_animal}/adotar`
- GetAllAdopted: `base_url/api/v1/adotados`

## Como executar o projeto

1. Clone o repositório e acesse a pasta do projeto:

```bach
git clone https://github.com/NBorego/adocao-animais.git
cd adocao-animais
```

2. Execute os comandos Docker abaixo para construir a imagem e subir os containers:

```bash
docker compose -f compose.yaml up --build
```
Caso os containers não tenham iniciado, utilize:

```bash
docker compose up
```

Acesse em [http://localhost/api/v1/animais](http://localhost/api/v1/animais)