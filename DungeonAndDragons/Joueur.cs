namespace DungeonAndDragons.Domain.Core;

public interface Joueur {

    RésultatD20 LancerD20();

    int Lancer(TypeDeDé d20);

}