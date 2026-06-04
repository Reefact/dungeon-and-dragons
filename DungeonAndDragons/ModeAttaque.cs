namespace DungeonAndDragons.Domain.Core;

public interface ModeAttaque {

    Caractéristique   CaractéristiqueUtilisée { get; }
    ComposantDeDégâts Dégâts                  { get; }

}