# [Chapitre 0 - Avant que tout commence](https://codadvent.fr/?day=00)

Bienvenue pour cette édition 2026 de notre calendrier de l'Avent [Coda](https://coda.school/).
Cette première aventure est une mise en bouche servant à te mettre dans le contexte.

## Comment ça marche

- Un défi sera publié chaque jour, du **1er au 24 décembre**, directement sur le site.
- Les thèmes et les langages changent d'un jour à l'autre : algorithmique, robustesse, système, base de données, ...
- Chacun·e avance à son rythme, avec son propre code, sur sa propre machine. Il n'y a rien à rendre ni à soumettre ici.
- Tu bloques, tu hésites, tu veux comparer ton raisonnement ? Le canal Discord dédié au calendrier est fait pour ça : pose tes questions, aide les autres, partage tes doutes.

> Seule règle : on discute des pistes, on ne balance pas la solution complète - histoire de laisser à tout le monde le plaisir de chercher.

## En attendant l'aventure...

Avant de rejoindre l'aventure, tu dépannes encore quelques clients.

Le dernier en date : **SockMatch**, une startup qui a développé une appli pour retrouver la chaussette jumelle perdue au lavage. Tu scannes ta chaussette solitaire, l'appli compare son motif, sa couleur, sa matière, sa taille et son pouvoir chauffant avec le reste de ton stock, et te donne un score de compatibilité. Le fondateur t'écrit en urgence.

> « On a un souci bizarre : même quand on scanne deux chaussettes strictement identiques, l'appli n'annonce jamais "c'est une paire !". Notre règle est pourtant simple : deux chaussettes forment une paire dès que leur score de compatibilité atteint 100%. Tu peux jeter un œil avant qu'on perde tous nos utilisateurs ? »

Le code tourne, le score se calcule, mais quelque chose cloche pile sur le cas parfait.

## Ta mission

- Récupère le code source (bouton **Télécharger les sources** ci-dessous) dans le langage de ton choix (`TypeScript`, `Java`, `C#` ou `PHP`).
- Lance les tests fournis : l'un d'eux reproduit le bug expliqué par ton client et échoue.
- Identifie la cause du bug, puis corrige le code - sans modifier les tests, qui décrivent la règle métier attendue.

## Règle métier

Le score de compatibilité additionne des points selon les caractéristiques comparées entre les deux chaussettes :

- **Motif** identique : **25 points**
- **Couleur** identique : **20 points**
- **Matière** identique : **20 points**
- **Taille** : jusqu'à **20 points**, avec un malus de 4 points par pointure d'écart
- **Pouvoir chauffant** (échelle de 1 à 10) : jusqu'à **15 points**, avec un malus de 3 points par point d'écart
- **Bonus qualité** : si les cinq caractéristiques correspondent strictement, **5 points** de bonus s'ajoutent

Deux chaussettes forment une paire dès que le score atteint **100 ou plus**. Une paire strictement identique dépasse donc les 100 points grâce au bonus.

Voici le code envoyé par SockMatch :

```typescript
export interface Sock {
    size: number;
    color: string;
    material: string;
    pattern: string;
    warmth: number;
}

export class SockMatcher {
    private static readonly PATTERN_WEIGHT = 25;
    private static readonly COLOR_WEIGHT = 20;
    private static readonly MATERIAL_WEIGHT = 20;
    private static readonly SIZE_WEIGHT = 20;
    private static readonly SIZE_PENALTY_PER_POINT = 4;
    private static readonly WARMTH_WEIGHT = 15;
    private static readonly WARMTH_PENALTY_PER_POINT = 3;
    private static readonly PERFECT_MATCH_BONUS = 5;
    private static readonly PERFECT_MATCH_SCORE = 100;

    public static computeCompatibilityScore(a: Sock, b: Sock): number {
        let score = 0;

        const samePattern = a.pattern === b.pattern;
        const sameColor = a.color === b.color;
        const sameMaterial = a.material === b.material;
        const sameSize = a.size === b.size;
        const sameWarmth = a.warmth === b.warmth;

        score += samePattern ? SockMatcher.PATTERN_WEIGHT : 0;
        score += sameColor ? SockMatcher.COLOR_WEIGHT : 0;
        score += sameMaterial ? SockMatcher.MATERIAL_WEIGHT : 0;
        score += Math.max(0, SockMatcher.SIZE_WEIGHT - Math.abs(a.size - b.size) * SockMatcher.SIZE_PENALTY_PER_POINT);
        score += Math.max(0, SockMatcher.WARMTH_WEIGHT - Math.abs(a.warmth - b.warmth) * SockMatcher.WARMTH_PENALTY_PER_POINT);

        if (samePattern && sameColor && sameMaterial && sameSize && sameWarmth) {
            score += SockMatcher.PERFECT_MATCH_BONUS;
        }

        return score;
    }

    public static isPair(a: Sock, b: Sock): boolean {
        return SockMatcher.computeCompatibilityScore(a, b) === SockMatcher.PERFECT_MATCH_SCORE;
    }
}
```

> Bientôt, l'histoire commence pour de vrai !!!