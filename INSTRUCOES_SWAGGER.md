# 🔧 Como Resolver o Problema do Swagger

## Problema: Swagger carrega mas não mostra resultados

### Solução Passo a Passo:

1. **Pare a API que está rodando:**
   - No terminal onde a API está rodando, pressione `Ctrl + C`
   - Aguarde até ver a mensagem de que o processo foi encerrado

2. **Reinicie a API:**
   ```powershell
   cd C:\Users\eosor\Desktop\GS2-C#\SkillUp.API
   dotnet run
   ```

3. **Aguarde a mensagem:**
   ```
   Now listening on: http://localhost:5000
   Now listening on: https://localhost:5001
   Application started. Press Ctrl+C to shut down.
   ```

4. **Acesse o Swagger:**
   - Abra o navegador
   - Digite: `http://localhost:5000/swagger`
   - OU: `https://localhost:5001/swagger`

5. **Teste um endpoint:**
   - Clique em `GET /api/v1/Courses`
   - Clique em "Try it out"
   - Clique em "Execute"
   - Você deve ver os 3 cursos retornados

---

## ⚠️ Se ainda não funcionar:

### Verifique se a API está rodando:
```powershell
# Ver processos dotnet rodando
Get-Process -Name "dotnet" -ErrorAction SilentlyContinue
```

### Se houver processos, mate-os:
```powershell
# Parar todos os processos dotnet
Stop-Process -Name "dotnet" -Force
```

### Depois reinicie:
```powershell
cd C:\Users\eosor\Desktop\GS2-C#\SkillUp.API
dotnet run
```

---

## ✅ O que você deve ver no Swagger:

1. **Página carregada completamente** (não apenas "carregando")
2. **Seções expandidas:**
   - Courses
   - Skills
   - Users
   - UserSkills
3. **Cada endpoint com botão colorido:**
   - 🔵 Azul = GET
   - 🟢 Verde = POST
   - 🟠 Laranja = PUT
   - 🔴 Vermelho = DELETE

4. **Ao clicar em "Try it out" e "Execute":**
   - Response Code: 200
   - Response Body: JSON com os dados

---

## 🎯 Teste Rápido:

1. Acesse: `http://localhost:5000/swagger`
2. Clique em: `GET /api/v1/Courses`
3. Clique em: "Try it out"
4. Clique em: "Execute"
5. **Resultado esperado:**
   ```json
   [
     {
       "id": 1,
       "title": "Fundamentos de IA",
       "description": "Curso introdutório sobre Inteligência Artificial",
       "duration": 40,
       "instructor": "Dr. João Silva",
       "price": 299.99,
       "createdAt": "2025-11-15T..."
     },
     ...
   ]
   ```

Se você ver isso, está funcionando! ✅

