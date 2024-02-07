# Capter 3-2 Unity 게임 개발 숙련 개인과제

## 과제1

### 필수 요구 사항

1. ATM 화면 구성
   - Title
   - 이름
   - 잔액 - 기본 50,000원
   - 현금 - 기본 100,000원
   - 입금 버튼 -> 2. 입금 기능으로 이동
   - 출금 버튼 -> 3. 출금 기능으로 이동

     ![image](https://github.com/chai227chai/SpartaBank/assets/37549333/06bb0609-3284-4051-b7bd-027db58c3934)

2. 입금 기능

   ![image](https://github.com/chai227chai/SpartaBank/assets/37549333/4ab8ca98-e08a-4ec6-8885-701c46e8e5ee)

   - 입금 화면 UI 구성
   - 버튼을 누르면 해당 금액 만큼 현금에서 잔액으로 이동

     ![image](https://github.com/chai227chai/SpartaBank/assets/37549333/c3b35a55-8f25-4679-a2cd-250b941ec87f)

   - 직접 입력을 이용하면 입력한 금액만큼 입금
   - 뒤로가기 버튼을 누르면 1번 화면으로 이동
   - 잔액이 부족하면 팝업 띄우기
      - 잔액 부족
             - 3만원이 있을 때 5만원 입금 하려면 잔액 부족
      - 확인 버튼 누르면 팝업 닫기
    
        ![image](https://github.com/chai227chai/SpartaBank/assets/37549333/8cbadcb6-baac-463d-b06c-b90182a82ca1)

 3. 출금 기능

    ![image](https://github.com/chai227chai/SpartaBank/assets/37549333/9286da3a-a972-4364-9081-f7bcae8ea77c)

    - 출금 화면 UI 구성
    - 버든을 누르면 해당 금액 만큼 잔액에서 현금으로 이동

      ![image](https://github.com/chai227chai/SpartaBank/assets/37549333/efb21f03-e424-4772-9212-5b45739a4910)

    - 직접 입력을 이용하면 입력한 금액만큼 입금
    - 뒤로가기 버튼을 누르면 1번 화면으로 이동
    - 잔액이 부족하면 팝업 띄우기
      - 잔액 부족
             - 3만원이 있을 때 5만원 출금 하려면 잔액 부족
      - 확인 버튼 누르면 팝업 닫기
     
        ![image](https://github.com/chai227chai/SpartaBank/assets/37549333/9393af6a-56a6-47a1-9adb-cbd83cf1be14)

---

### 선택 요구 사항


1. 통화 단위 적용
   - 1000의 자리 마다 , 표시
   - 1000원이면 1,000
   - 50000원이면 50,000
     
2.금액 입력시 숫자만 입력
   - 인풋박스에 숫자외에 입력 안되게 적용

3.로그인 기능

   ![image](https://github.com/chai227chai/SpartaBank/assets/37549333/f0c81aa1-cc16-4695-b2bf-dc09fb18bc5d)

   - 실행하면 **필수요구사항 1.ATM** 대신 로그인 화면이 먼저 나타납니다.
   - 아이디와 비밀번호를 입력하면 **필수요구사항 1.ATM** 으로 이동
   - ~~아이디와 비밀번호는 아무값이나 입력해도 상관 없습니다.~~ -> 아이디와 비밀번호가 일치해야 화면이 넘어가도록 변경
     
     ![image](https://github.com/chai227chai/SpartaBank/assets/37549333/948f3d2e-40db-4bd1-8b90-3b19312e4ad6)

   - 비밀번호 입력 시 마스킹을 통해 ***으로 표시됩니다.

     ![image](https://github.com/chai227chai/SpartaBank/assets/37549333/9208ada8-4f0f-4c9f-8439-bc3f46fc59d6)

4. 회원가입

   ![image](https://github.com/chai227chai/SpartaBank/assets/37549333/23786062-1d4f-47b0-85c8-473176653c48)

   - ID - 영어, 숫자 3글자 이상 ~ 10글자 이하

   이미 있는 아이디면 가입 불가

   - Name - 2글자 ~ 5글자
   - PS - 영어, 숫자 5글자 이상 ~ 15글자 이하
   - PS Confirm - PS와 동일한지 확인
   - PS, PS Confirm - 입력 시 *** 마스킹 처리
  
     ![image](https://github.com/chai227chai/SpartaBank/assets/37549333/93a6ad36-95f0-4b14-a49f-a383ea1b017c)

   - 회원가입 조건이 안맞는 다면 Sign Up 시 에러 팝업 및 메세지

     ![image](https://github.com/chai227chai/SpartaBank/assets/37549333/d57fcbf0-973a-45cb-9233-5b50eceef276)

     ![image](https://github.com/chai227chai/SpartaBank/assets/37549333/9925a737-5621-4cf9-862f-a634a5f2cfc4)

   - 회원가입 시 PlayerPefs를 이용하여 껏다 켜도 정보 유지되도록 유지














