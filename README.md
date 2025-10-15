# api

## Inventaire

Les stocks ne sont pas gérés comme un champ qu'on vient incrémenter ou décrémenter. Les stocks sont le calcul de l'ensemble des écritures dans le registre article.

L'ajustement du stock se fait par les feuilles d'inventaires. L'opérateur renseigne ainsi le stock réel. Une fois validée, les écritures nécessaires dans le registre sont crées.

```mermaid
    sequenceDiagram

    InventoryLine->>InventoryHeader: Déclaration quantités réelles
    InventoryHeader->>ItemLedger: Validation feuille, création d'entrées dans le registre pour ajustement des écarts
```

## Vente

```mermaid
    sequenceDiagram

    Commande_vente->>Panier: Statut: Cart
    Panier->>Commande_vente: Statut: Released - Déclenchement Cmd achat si auto
    Commande_vente->>ItemLedger: Statut: Posted (Validée est considérée comme expédiée). Stock requis
```

## Achat

```mermaid
    sequenceDiagram

    Inventaire_insuffisant->>Commande_achat: Génération automatique ou manuelle selon paramétrage
    Commande_achat->>Panier: Statut de départ pour l'ajout des articles
    Panier->>Commande_achat: En cours, demande au fournisseur
    Commande_achat->>ItemLedger: Validée - mise en stock via le registre
```
