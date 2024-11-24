import pandas as pd


def remove_duplicate_questions():
    try:
        # 直接使用相对路径
        df = pd.read_csv("jokes.csv")

        # 删除重复的问题
        df = df.drop_duplicates(subset=["question"], keep="first")

        # 保存到新文件
        df.to_csv("jokes_processed.csv", index=False)

        print("Processing completed successfully")

    except Exception as e:
        print(f"Error occurred: {str(e)}")


if __name__ == "__main__":
    remove_duplicate_questions()
