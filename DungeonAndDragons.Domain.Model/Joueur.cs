namespace DungeonAndDragons.Domain.Model;

public interface Joueur {

    RésultatD20 LancerD20();

    int Lancer(TypeDeDé d20);

}