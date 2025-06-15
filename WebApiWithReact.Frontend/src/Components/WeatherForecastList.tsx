import apiClient from '../Api/ApiClient';
import React, { useState, useEffect } from 'react';
import { Card, ListGroup } from 'react-bootstrap';

interface WeatherForecast {
    date: string;
    temperatureC: number;
    summary: string
}

const WeatherForecastList: React.FC = () => {
    const [weatherForecasts, setWeatherForecasts] = useState<WeatherForecast[]>([]);

    useEffect(() => {
        const fetchProducts = async () => {
            try {
                const response = await apiClient.get<WeatherForecast[]>('/weatherforecast');
                setWeatherForecasts(response.data);
            } catch (error) {
                console.error('Ошибка при загрузке прогнозов:', error);
            }
        };

        fetchProducts();
    }, []);

    return (
        <Card>
            <Card.Header>Прогноз погоды</Card.Header>
            <Card.Body>
                <ListGroup>
                    {weatherForecasts.map(weatherForecast => (
                        <ListGroup.Item>
                            <h3>{new Date(weatherForecast.date).toDateString()}</h3>
                            <p>Температура: {weatherForecast.temperatureC} градусов</p>
                            <p>{weatherForecast.summary}</p>
                        </ListGroup.Item>
                    ))}
                </ListGroup>
            </Card.Body>
        </Card>
    );  
};

export default WeatherForecastList;