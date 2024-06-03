public class ComputerGameAdapter : PCGame
{
    private ComputerGame computerGame;

    // Конструктор, который принимает объект ComputerGame и сохраняет его
    public ComputerGameAdapter(ComputerGame computerGame)
    {
        this.computerGame = computerGame;
    }

    // Возвращает название игры
    public string getTitle()
    {
        return computerGame.getName();
    }

    // Возвращает минимальный возраст игрока на основе рейтинга PEGI
    public int getPegiAllowedAge()
    {
        // Преобразует значение enum PegiAgeRating в целое число, представляющее минимальный возраст
        switch (computerGame.getPegiAgeRating())
        {
            case PegiAgeRating.P3:
                return 3;
            case PegiAgeRating.P7:
                return 7;
            case PegiAgeRating.P12:
                return 12;
            case PegiAgeRating.P16:
                return 16;
            case PegiAgeRating.P18:
                return 18;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    // Определяет, является ли игра Triple-A на основе бюджета
    public bool isTripleAGame()
    {
        // Отмечает игру как Triple-A, если ее бюджет превышает 50 миллионов долларов
        return computerGame.getBudgetInMillionsOfDollars() > 50;
    }

    // Возвращает системные требования игры
    public Requirements getRequirements()
    {
        // Преобразует требования из ComputerGame в объект Requirements
        int gpuGb = computerGame.getMinimumGpuMemoryInMegabytes() / 1024;
        int hddGb = computerGame.getDiskSpaceNeededInGB();
        int ramGb = computerGame.getRamNeededInGb();
        double cpuGhz = computerGame.getCoreSpeedInGhz();
        int coresNum = computerGame.getCoresNeeded();

        return new Requirements(gpuGb, hddGb, ramGb, cpuGhz, coresNum);
    }
}
