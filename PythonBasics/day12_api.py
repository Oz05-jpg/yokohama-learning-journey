import json
from urllib import response
import requests

def get_user_data(user_id):
    url = f"https://jsonplaceholder.typicode.com/users/{user_id}"
    response = requests.get(url)

    try:
        response.raise_for_status()  # ตรวจสอบว่าการเรียก API สำเร็จหรือไม่
        data = response.json()  # แปลงข้อมูล JSON เป็น Python dict
        return data["name"], data["email"]  # ดึงชื่อและอีเมลของผู้ใช้
    except requests.exceptions.HTTPError as e:
        return None, None  # หากเกิดข้อผิดพลาดในการเรียก API ให้คืนค่า None

print(get_user_data(1))  # ทดสอบฟังก์ชันด้วย user ID 1

#list of user IDs to fetch
def fetch_users(user_ids):
    users = []
    for user_id in user_ids:
        user_name, email = get_user_data(user_id)
        users.append({"name": user_name, "email": email})
    return users


#สร้างฟังก์ชันเพื่อดึงข้อมูลผู้ใช้ทั้งหมดและบันทึกเป็นไฟล์ CSV
def save_users_to_csv(data, filename):
    # แปลงข้อมูล JSON เป็น CSV และบันทึกลงไฟล์
    import csv
    with open(filename, mode='w', newline='', encoding='utf-8') as file:
        writer = csv.DictWriter(file, fieldnames=data[0].keys())
        # เขียน header
        writer.writeheader()
        # เขียนข้อมูลแต่ละแถว
        for user in data:
            writer.writerow(user)

user_ids = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]  # ตัวอย่าง user IDs ที่ต้องการดึงข้อมูล
result = fetch_users(user_ids)  # ดึงข้อมูลผู้ใช้จาก API
if any(user["name"] is None for user in result):
    print("ดึงข้อมูลผู้ใช้บางส่วนไม่สำเร็จ บันทึกไฟล์ไม่ได้ ❌")

else:
    save_users_to_csv(result, "users_report_output.csv")
    print("Report saved ✅")