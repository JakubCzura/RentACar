export class MakeReservationDto {
    constructor(
        public startDate: Date | null,
        public endDate: Date | null,
        public carId?: number,
        public pickupLocationId?: number,
        public dropoffLocationId?: number,
        public userId?: number
    ) { }
}