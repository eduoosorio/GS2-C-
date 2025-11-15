# ✅ Checklist de Entrega - SkillUp API

## 📋 O que você precisa entregar:

### 1. ✅ **Boas Práticas (30 pts)** - JÁ IMPLEMENTADO

- [x] API RESTful com verbos HTTP corretos (GET, POST, PUT, DELETE)
- [x] Status codes adequados (200, 201, 400, 404, 500)
- [x] Separação de Controllers, Services e Repositories
- [x] Padrão DTO implementado
- [x] AutoMapper configurado e funcionando

**Status:** ✅ COMPLETO

---

### 2. ✅ **Versionamento da API (10 pts)** - JÁ IMPLEMENTADO

- [x] Rotas `/api/v1/...` implementadas
- [x] Rotas `/api/v2/...` implementadas
- [x] Endpoint extra na v2: `/api/v2/skills/top`
- [x] Versionamento explicado no README

**Status:** ✅ COMPLETO

---

### 3. ✅ **Integração e Persistência (30 pts)** - JÁ IMPLEMENTADO

- [x] Banco de dados configurado (SQLite - pode trocar para SQL Server se preferir)
- [x] Entity Framework Core implementado
- [x] Migrations criadas e aplicadas
- [x] Entidade **User** com CRUD completo
- [x] Entidade **Skill** com CRUD completo
- [x] Entidade **Course** com CRUD completo
- [x] Entidade **UserSkill** (relacionamento N:N) com CRUD completo

**Status:** ✅ COMPLETO

---

### 4. ⚠️ **Documentação (30 pts)** - PARCIALMENTE COMPLETO

#### ✅ Já feito:
- [x] Swagger totalmente configurado e funcionando
- [x] README.md completo com:
  - [x] Objetivo do projeto
  - [x] Como rodar
  - [x] Funcionalidades
  - [x] Tecnologias usadas
  - [x] Exemplos de requests/responses
  - [x] Instruções sobre versionamento
  - [x] Nomes dos integrantes

#### ⚠️ FALTA FAZER:
- [ ] **Fluxo da aplicação no Draw.io** - Criar diagrama e adicionar no README
- [ ] **Link do vídeo demonstrativo** - Gravar vídeo (máx 5 minutos) e adicionar link no README

**Status:** ⚠️ FALTA 2 ITENS

---

### 5. 📤 **Entrega Final**

#### O que fazer:
1. [ ] **Criar diagrama no Draw.io** do fluxo de dados
   - Acesse: https://app.diagrams.net/ (Draw.io)
   - Crie o diagrama baseado no que está no README (seção "Fluxo da Aplicação")
   - Exporte como imagem (PNG ou JPG)
   - Adicione a imagem no README.md

2. [ ] **Gravar vídeo demonstrativo** (máximo 5 minutos)
   - Mostre o Swagger funcionando
   - Teste alguns endpoints (GET, POST, PUT, DELETE)
   - Mostre o versionamento (v1 e v2)
   - Teste o endpoint `/api/v2/skills/top`
   - Mostre o banco de dados (opcional)
   - Faça upload no YouTube ou plataforma similar
   - Adicione o link no README.md

3. [ ] **Fazer upload no GitHub**
   - Criar repositório no GitHub
   - Fazer commit de todos os arquivos
   - Fazer push para o GitHub
   - Verificar se o README está completo

4. [ ] **Entregar no Teams**
   - Enviar o link do repositório GitHub no Teams
   - Verificar se o README contém:
     - ✅ Nomes dos integrantes
     - ✅ Documentação completa
     - ✅ Funcionalidades
     - ✅ Forma de funcionamento
     - ✅ Fluxo de Dados (Draw.io) - **ADICIONAR**
     - ✅ Link do vídeo - **ADICIONAR**

---

## 🎯 Resumo do que falta:

1. **Criar diagrama no Draw.io** e adicionar no README
2. **Gravar vídeo** (máx 5 min) e adicionar link no README
3. **Fazer upload no GitHub**
4. **Entregar link no Teams**

---

## 📝 Como adicionar o diagrama no README:

1. Crie o diagrama no Draw.io
2. Exporte como PNG ou JPG
3. Salve a imagem na pasta do projeto (ex: `docs/fluxo-dados.png`)
4. No README.md, adicione:
   ```markdown
   ## 📊 Fluxo da Aplicação
   
   ![Fluxo de Dados](docs/fluxo-dados.png)
   ```

---

## 🎥 O que mostrar no vídeo:

1. **Abrir o Swagger** (30 seg)
2. **Mostrar os endpoints v1** (1 min)
   - GET /api/v1/users
   - POST /api/v1/users
   - GET /api/v1/skills
3. **Mostrar versionamento** (30 seg)
   - Trocar de v1 para v2 no Swagger
4. **Testar endpoint exclusivo v2** (1 min)
   - GET /api/v2/skills/top
5. **Testar outros verbos** (1 min)
   - PUT (atualizar)
   - DELETE (deletar)
6. **Resumo final** (30 seg)

**Total: ~5 minutos**

---

## ✅ Checklist Final antes de entregar:

- [ ] Diagrama Draw.io adicionado no README
- [ ] Link do vídeo adicionado no README
- [ ] Projeto no GitHub
- [ ] README completo e revisado
- [ ] Link do repositório enviado no Teams

---

**Boa sorte com a entrega! 🚀**

