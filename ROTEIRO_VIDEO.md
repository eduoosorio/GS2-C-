# 🎥 Roteiro do Vídeo Demonstrativo (Máximo 5 minutos)

## 📋 O que você precisa gravar:

### ⏱️ Estrutura do Vídeo (5 minutos):

---

## 1️⃣ **INTRODUÇÃO (30 segundos)**

**O que mostrar:**
- Tela inicial do Swagger aberto
- Dizer: "Este é o projeto SkillUp API, uma API RESTful para gerenciamento de competências profissionais"

**O que falar:**
- "Olá, este é o projeto SkillUp API desenvolvido em ASP.NET Core"
- "Vou demonstrar as funcionalidades principais da API"

---

## 2️⃣ **MOSTRAR O SWAGGER E ESTRUTURA (1 minuto)**

**O que mostrar:**
- Swagger UI completo na tela
- Mostrar as seções: Courses, Skills, Users, UserSkills
- Mostrar o dropdown de versões (v1 e v2)
- Rolar a tela mostrando todos os endpoints

**O que falar:**
- "Aqui temos a documentação interativa da API no Swagger"
- "Temos 4 recursos principais: Courses, Skills, Users e UserSkills"
- "A API possui versionamento, com versão 1 e versão 2"
- "Cada recurso possui operações CRUD completas: GET, POST, PUT e DELETE"

---

## 3️⃣ **TESTAR ENDPOINTS V1 - GET (1 minuto)**

**O que mostrar:**
- Clicar em `GET /api/v1/Courses`
- Clicar em "Try it out"
- Clicar em "Execute"
- Mostrar a resposta com status 200 e os dados JSON
- Fazer o mesmo com `GET /api/v1/Users` ou `GET /api/v1/Skills`

**O que falar:**
- "Vou testar o endpoint GET para listar cursos"
- "A resposta retorna status 200 com os dados em JSON"
- "Como podemos ver, temos cursos cadastrados no banco de dados"

---

## 4️⃣ **TESTAR ENDPOINTS V1 - POST (1 minuto)**

**O que mostrar:**
- Clicar em `POST /api/v1/Users`
- Clicar em "Try it out"
- Preencher o JSON:
  ```json
  {
    "name": "João Silva",
    "email": "joao.silva@email.com"
  }
  ```
- Clicar em "Execute"
- Mostrar a resposta com status 201 e o usuário criado

**O que falar:**
- "Agora vou criar um novo usuário usando POST"
- "Preencho os dados no formato JSON"
- "A resposta retorna status 201 Created, indicando que o recurso foi criado com sucesso"
- "O objeto retornado inclui o ID gerado automaticamente"

---

## 5️⃣ **MOSTRAR VERSIONAMENTO - V2 (1 minuto)**

**O que mostrar:**
- Clicar no dropdown no topo do Swagger
- Selecionar "SkillUp API v2"
- Mostrar que aparecem os mesmos endpoints da v1
- Clicar em `GET /api/v2/skills/top`
- Clicar em "Try it out"
- Preencher `top: 5` (ou deixar padrão)
- Clicar em "Execute"
- Mostrar a resposta com o ranking

**O que falar:**
- "Agora vou demonstrar o versionamento da API"
- "Ao trocar para a versão 2, temos acesso ao endpoint exclusivo `/skills/top`"
- "Este endpoint retorna o ranking das habilidades mais cadastradas pelos usuários"
- "Isso demonstra como o versionamento permite adicionar novas funcionalidades sem quebrar a v1"

---

## 6️⃣ **TESTAR PUT E DELETE (1 minuto)**

**O que mostrar:**
- Clicar em `PUT /api/v1/Courses/{id}` (usar ID 5 ou outro existente)
- Clicar em "Try it out"
- Preencher o ID (ex: 5)
- Preencher o JSON com dados atualizados
- Clicar em "Execute"
- Mostrar status 200
- Depois mostrar `DELETE /api/v1/Courses/{id}`
- Executar e mostrar status 200

**O que falar:**
- "Vou demonstrar a atualização de um recurso com PUT"
- "E também a exclusão com DELETE"
- "Ambos retornam status 200 quando bem-sucedidos"

---

## 7️⃣ **CONCLUSÃO (30 segundos)**

**O que mostrar:**
- Voltar para a tela inicial do Swagger
- Mostrar rapidamente todos os endpoints disponíveis

**O que falar:**
- "Esta API implementa todas as boas práticas RESTful"
- "Possui versionamento, documentação Swagger completa"
- "E está integrada com banco de dados usando Entity Framework Core"
- "Obrigado por assistir!"

---

## 📝 CHECKLIST ANTES DE GRAVAR:

- [ ] Swagger está funcionando
- [ ] API está rodando
- [ ] Testei todos os endpoints que vou mostrar
- [ ] Preparei o que vou falar (pode usar este roteiro)
- [ ] Configurei a gravação de tela
- [ ] Áudio está funcionando

---

## 🎬 DICAS PARA GRAVAR:

1. **Fale pausadamente** - Não tenha pressa
2. **Mostre a tela completa** - Deixe o Swagger visível
3. **Use zoom se necessário** - Para mostrar melhor os detalhes
4. **Teste antes de gravar** - Garanta que tudo funciona
5. **Edite se necessário** - Corte pausas longas depois

---

## ⏱️ TEMPO ESTIMADO:

- Introdução: 30s
- Swagger e estrutura: 1min
- GET: 1min
- POST: 1min
- Versionamento v2: 1min
- PUT e DELETE: 1min
- Conclusão: 30s

**Total: ~6 minutos** (pode cortar alguns segundos em cada parte para ficar em 5 minutos)

---

## 🎯 PONTOS IMPORTANTES PARA DESTACAR:

1. ✅ **Status codes corretos** (200, 201, 404, etc.)
2. ✅ **Versionamento** (v1 e v2)
3. ✅ **Swagger funcionando**
4. ✅ **CRUD completo** (GET, POST, PUT, DELETE)
5. ✅ **Respostas em JSON**
6. ✅ **Endpoint exclusivo v2** (`/skills/top`)

---

## 📤 ONDE PUBLICAR:

- **YouTube** (recomendado)
- **Google Drive** (compartilhar link)
- **OneDrive** (compartilhar link)
- Qualquer plataforma que permita link público

---

**Boa gravação! 🎥**

