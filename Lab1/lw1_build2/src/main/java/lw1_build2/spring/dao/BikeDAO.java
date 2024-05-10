package lw1_build2.spring.dao;

import lw1_build2.spring.model.Bike;

import java.util.List;

public interface BikeDAO {
    public void addBike(Bike bike);
    public void updateBike(Bike bike);
    public void removeBike(int id);
    public List<Bike> listBikes();
    public Bike getBikeById(int id);
}
