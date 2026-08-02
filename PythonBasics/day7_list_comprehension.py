# Python Day 7 — Exercise L1 (Guided)
# List Comprehension: ย่อ for-loop ที่สร้าง list ให้เหลือบรรทัดเดียว
# เทียบ LINQ: machines.Where(m => m.IssueCount > threshold).Select(m => m.Name)
#
# เติม ??? ให้ครบ แล้วรันด้วย: python day7_list_comprehension.py

machines = [
    {"name": "เครื่องอัดยาง B2", "issue_count": 5},
    {"name": "เครื่องตัด C3", "issue_count": 2},
    {"name": "เครื่องผสม A1", "issue_count": 4},
    {"name": "เครื่องบรรจุ D4", "issue_count": 1},
    {"name": "เครื่องส่งสายพาน A1", "issue_count": 3},
    {"name": "เครื่องหลอมยาง E5", "issue_count": 6},
    {"name": "เครื่องพิมพ์ลาย F6", "issue_count": 0},
    {"name": "เครื่องตรวจสอบคุณภาพ G7", "issue_count": 3},
    {"name": "เครื่องเป่าลม H8", "issue_count": 7},
    {"name": "เครื่องแพ็คสินค้า I9", "issue_count": 2},
]

# เดิม (for-loop แบบ Day 1) — ห้ามแก้ ไว้เทียบกัน
def find_unreliable_machines_old(machines_list, threshold):
    result = []
    for machine in machines_list:
        if machine["issue_count"] > threshold:
            result.append(machine["name"])
    return result


# ใหม่ — เติม List Comprehension แทน (ผลลัพธ์ต้องเหมือนตัวบนเป๊ะ)
def find_unreliable_machines_new(machines_list, threshold):
    return [machine["name"] 
            for machine in machines_list 
            if machine["issue_count"] > threshold]



old_result = find_unreliable_machines_old(machines, 3)
new_result = find_unreliable_machines_new(machines, 3)

print("Old:", old_result)
print("New:", new_result)
print("เหมือนกันไหม:", old_result == new_result)   # TODO 5: ต้องได้ True


# List Comprehension (independent)
def find_high_issue_summary(machines_list, threshold):
    return [f"{machine['name']} มี issue_count = {machine['issue_count']} ครั้ง"
            for machine in machines_list 
            if machine["issue_count"] >= threshold]

high_issue_summary = find_high_issue_summary(machines, 5)
print("High Issue Summary:", "\n".join(high_issue_summary))   # TODO 6: ต้องได้ list ของ string ที่มี issue_count >= 5
print("จำนวนเครื่องที่มี issue_count >= 5:", len(high_issue_summary) , "เครื่อง")   # TODO 7: ต้องได้ 3