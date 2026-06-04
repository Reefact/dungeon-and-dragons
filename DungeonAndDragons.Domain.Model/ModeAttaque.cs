namespace DungeonAndDragons.Domain.Model;

public interface ModeAttaque {

    Caractéristique   CaractéristiqueUtilisée { get; }
    ComposantDeDégâts Dégâts                  { get; }

}