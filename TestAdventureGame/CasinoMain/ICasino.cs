using SpaceAdventure.PlayerCharacter;

namespace SpaceAdventure.CasinoMain
{
    public interface ICasino
    {
        decimal Bet(Player player);
        void CasinoOptions(Player player);
        void CasinoSlots(Player player);
        void PlayBlackJack(Player player);
        void PlayPazaak(Player player);
    }
}