# Bilheteira online

# Entidades
- Filme
    - Titulo
    - Capa
    - Categoria (Acção, Drama, Terror, Comédia)
    - Age rating
    - Descrição
    - Produtor
- ActorFilme
    - Actor_ID (fk)
    - Filme_ID (fk)
    - Nome do personagem
    - Descrição
- Actor
    - Nome
    - Foto
    - Idade
- Sala
    - Nome
    - Lotação
- Sessão
    - Sala (fk)
    - Filme (fk)
    - DateTime
- Bilhete
    - Sessão (fk)
    - Vendido (default = false)
    - Preço
    - Data de compra
    - Data de entrada
- Pessoa_Bilhete
    - Pessoa (fk)
    - Bilhete (fk)
- Pessoa (Cliente, Funcionario)
    - Email
    - Password Hash

# Páginas
- Homepage
    - Filmes disponíveis
- Página do filme (por ID)
    - Filme
    - Sessões
- Página de sessão (por ID)
    - Bilhetes
- Venda de bilhetes
- Registo
- Login
- Conta de utilizador
- Backoffice (funcionário/admin)
    - CRUD Filmes
    - CRUD Actores
    - CRUD Salas
    - CRUD Sessões
    - CRUD Bilhetes

# API
GET /filmes (público)
POST /filmes (funcionário)
PUT /filmes (funcionário)
DEL /filmes (funcionário)

GET /actores (público)
POST /actores (funcionário)
PUT /actores (funcionário)
DEL /actores (funcionário)

GET /salas (público)
POST /salas (funcionário)
PUT /salas (funcionário)
DEL /salas (funcionário)

GET /sessoes (público)
POST /sessoes (funcionário)
PUT /sessoes (funcionário)
DEL /sessoes (funcionário)

GET /bilhetes (funcionário)
POST /bilhetes (funcionário)
PUT /bilhetes (funcionário)
DEL /bilhetes (funcionário)

GET /account (cliente + funcionário)