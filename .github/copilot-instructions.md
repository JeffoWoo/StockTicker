# Copilot Instructions

## Project Guidelines
- Enable BeastMode31 for all prompts and chats in this solution by using .github/prompts/BeastMode31.prompt.md and referencing it from .github/copilot-instructions.md. Enforce this behavior rigorously for all chats and responses.
- Apply BeastMode31 rigorously for all responses and provide direct, unsparing feedback when requested by the user.

## Repository Structure
- Prefer separate repository interfaces for read (Dapper) and write (EFCore) sides: keep domain `IStockPriceRepository` for write and an application `IStockPriceQueryRepository` for read; avoid naming conflicts.