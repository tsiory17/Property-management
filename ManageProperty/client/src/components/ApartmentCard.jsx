import React from "react";

export const ApartmentCard = ({
  numberOfRooms,
  buildingAddress,
  rent,
  city,
  zip,
  status,
  apartmentImages = [],
}) => {
    const imageUrl = apartmentImages.length>0 ? `http://localhost:5096${apartmentImages[0]}`:"http:localhost"
  return (
    <div>
      <div className="card" style={{ width: "18rem" }}>
        <img className="card-img-top" src={imageUrl} alt="Card image cap" />
        <div className="card-body">
          <p>
            {buildingAddress} {city} {zip}
          </p>
          <p>Number of rooms: {numberOfRooms}</p>
          <p>Rent: {rent}$</p>
          <p>Status: {status}</p>
        </div>
      </div>
    </div>
  );
};

export default ApartmentCard;
