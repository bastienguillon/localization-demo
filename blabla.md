# Thèse

Présentation de la récupération des entités traduites :
- Tables Products & ProductTranslations
- Vue LocalizedProducts
- CurrentContentCultureSetterMiddleware + query filters

# Antithèse

Présentation des limites de ce système : 
- Duplication du modèle de données: lecture VS écriture
- Ça bave : le modèle de données non traduit est également dupliqué ()
- Trop de responsabilités pour la couche Infra
- Cache EF

# Mayonnaise

Présentation d'une solution plus simple (Api V2)