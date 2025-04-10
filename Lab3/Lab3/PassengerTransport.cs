namespace Lab3;

public interface IPassengerTransport
{
    /// <summary>
    /// Рассчитать выручку за текущий маршрут.
    /// </summary>
    /// <returns>Общая выручка за маршрут.</returns>
    int GetRevenuePerRoute();

    /// <summary>
    /// Начать маршрут.
    /// </summary>
    /// <returns>True, если маршрут завершён успешно.</returns>
    bool StartRoute(string[] args);

    /// <summary>
    /// Сбросить состояние транспорта для нового маршрута.
    /// </summary>
    void Reset();

    /// <summary>
    /// Название транспорта.
    /// </summary>
    string TransportName { get; }
}