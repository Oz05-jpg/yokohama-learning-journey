class Technician:
    def __init__(self, name, specialty):
        self.name = name
        self.specialty = specialty

    def matches_specialization(self, target_specialty):
        return self.specialty == target_specialty


class Machine:
    def __init__(self, machine_id, status):
        self.id = machine_id
        self.status = status

    def is_operational(self): #อันนี้เป็น method ของ class Machine ที่ใช้ตรวจสอบสถานะของเครื่องจักร โดยจะ return True ถ้า status ของเครื่องจักรเป็น "Running" และ return False ถ้าไม่ใช่
        return self.status == "Running" 